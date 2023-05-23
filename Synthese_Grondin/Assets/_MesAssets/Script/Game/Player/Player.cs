using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] GameObject enemyBullet = default;

    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float missileForce = 40f;
    [SerializeField] public int numMissile = 10;

    [SerializeField] private int maxHealth = 40;
    [SerializeField] public int currentHealth = 40;

    [SerializeField] private Health healthBar;
    [SerializeField] private GameObject _playerHurt1 = default;
    [SerializeField] private GameObject _playerHurt2 = default;

    private float canFire = -1.0f;
    private SpawnManager spawnManager;
    private GestionUI gestionUI;
    private Animator anim;
    

    void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gestionUI = FindObjectOfType<GestionUI>().GetComponent<GestionUI>();
        anim = GetComponent<Animator>();    

        currentHealth = 40;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        numMissile = 10;
    }
    void Update()
    {
        Move();
        Shoot();

        healthBar.SetHealth(currentHealth); 
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * speed);

        CheckPosJoueur();

        if (horizontalInput < 0)
        {
            anim.SetBool("Turn_Left", true);
            anim.SetBool("Turn_Right", false);
        }
        else if (horizontalInput > 0)
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", true);
        }
        else
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", false);
        }
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

        if (Input.GetKeyDown(KeyCode.Mouse1) && numMissile > 0)
        {
            GameObject missile = Instantiate(missilePrefab, bulletTransform.position, bulletTransform.rotation);
            Rigidbody2D rb = missile.GetComponent<Rigidbody2D>();
            rb.AddForce(bulletTransform.up * missileForce, ForceMode2D.Impulse);

            numMissile--;
        }
        
    }

    public void Damage()
    {
        currentHealth--;

        if (currentHealth >= 20)
        {
            _playerHurt1.SetActive(true);
        }
        else if (currentHealth < 20)
        {
            _playerHurt1.SetActive(true);
            _playerHurt2.SetActive(true);
        }
        if (currentHealth < 1)
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
