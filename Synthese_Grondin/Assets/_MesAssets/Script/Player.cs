using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    private float canFire = -1.0f;
    

    void Start()
    {
        transform.position = new Vector3(0f, -4f, 0f);
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


}
