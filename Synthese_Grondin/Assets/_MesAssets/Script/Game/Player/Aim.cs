using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbPlayer = default; 
    private Camera mainCam;
    private Vector3 mousePosition;
   
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        weaponAim();
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        
    }

    private void weaponAim()
    {
        

        Vector3 rotation = mousePosition - transform.position;

        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;

        rbPlayer.rotation = angle;
    }

}
