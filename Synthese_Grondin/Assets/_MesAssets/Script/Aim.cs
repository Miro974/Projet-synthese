using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletTransform;


    private float _canfire = -1;
    [SerializeField] private float delai = 0.5f;


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        weaponAim();


    }

    private void weaponAim()
    {
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void shoot()
    { 
        if(Input.GetKeyDown(KeyCode.Mouse0) && _canfire > delai)
        {
            _canfire = Time.time + delai;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);

        }
    }
}
