using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private int enemyLife = 1;
    [SerializeField] private GameObject bulletPrefab = default;
    [SerializeField] private Transform firingPoint = default;
    [SerializeField] private float bulletForce = 10f;

    private float fireRate;
    private float canFire;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
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
