using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    private Transform WeaponParent;
    private Vector3 mousePos;
    private Player player;

    private void Awake()
    {
        WeaponParent = transform.Find("WeaponParent");
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        MousePosition();
    }

    private void MousePosition()
    {
        mousePos = Input.mousePosition;
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        WeaponParent.eulerAngles = new Vector3(0f, 0f, angle);

        //if (player.turned)
        //{
        //    WeaponParent.eulerAngles = new Vector3(0f, 170f, angle);
        //}
        //else if (!player.turned)
        //{ 
        //    WeaponParent.eulerAngles = new Vector3(0f, 0f, angle);
        //}
    }
}
