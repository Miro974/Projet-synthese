using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private int playerLife = 3;
    [SerializeField] GameObject enemyBullet = default;
    private float canFire = -1.0f;
    private SpawnManager spawnManager;
    

    void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void Update()
    {
        Move();
        Shoot();

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * speed);

        CheckPosJoueur();
    }

    private void CheckPosJoueur()
    {
        if (transform.position.x <= -35f)
        {
            transform.position = new Vector3(32f, transform.position.y, 0f);
        }
        else if (transform.position.x >= 35f)
        {
            transform.position = new Vector3(-32f, transform.position.y, 0f);
        }

        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(transform.position.x, 20f, 0f);
        }
        else if (transform.position.y >= 20f)
        {
            transform.position = new Vector3(transform.position.x, -20f, 0f);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletTransform.up * bulletForce, ForceMode2D.Impulse);
        }
        
    }

    public void Damage()
    {
        playerLife--;
        if (playerLife < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            enemyBullet = other.transform.GetComponent<GameObject>();
            Damage();
            Destroy(other.gameObject, 0f);
        }
    }


}
