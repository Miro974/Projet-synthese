using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Transform target = default;
    [SerializeField] private float distanceBetween;
    [SerializeField] private int enemyLife = 2;
    [SerializeField] private GameObject bulletPrefab = default;
    [SerializeField] private Transform firingPoint = default;
    [SerializeField] private float bulletForce = 10f;

    [SerializeField] private int points = 100;

    private GestionUI gestionUI;
    private float fireRate;
    private float canFire;
    private float distance;
    private Player _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        gestionUI = FindObjectOfType<GestionUI>().GetComponent<GestionUI>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        canFire = Random.Range(0.5f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        MoveEnemy();
        Shoot();
    }

    private void MoveEnemy()
    {
        if (_player.currentHealth > 0)
        { 
            distance = Vector3.Distance(transform.position, target.transform.position);
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            if (distance < distanceBetween)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
        
    }

    private void Shoot()
    {
        if (gestionUI.getScore() > 800)
        { 
            if (Time.time > canFire)
            {
                fireRate = 3.5f;
                canFire = Time.time + fireRate;
                GameObject enemyBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
                Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.transform.GetComponent<Player>();
            _player.Damage();
            Destroy(this.gameObject, 0f);
        }
        else if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            enemyLife--;
            if (enemyLife < 1)
            {
                Destroy(this.gameObject, 0f);
                gestionUI.AjouterScore(points);
            }
            
        }
    }
}
