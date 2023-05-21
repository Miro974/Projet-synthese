using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShots : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = default;
    [SerializeField] private Transform firingPoint = default;
    [SerializeField] private float bulletForce = 10f;

    private float fireRate;
    private float canFire;

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Time.time > canFire)
        {
            fireRate = .5f;
            canFire = Time.time + fireRate;
            GameObject enemyBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firingPoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
