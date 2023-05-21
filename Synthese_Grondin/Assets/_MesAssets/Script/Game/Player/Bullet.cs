using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        CheckBulletPos();
    }

    private void CheckBulletPos()
    {
        if (transform.position.x <= -35f)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.x >= 35f)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y <= -20f)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.y >= 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
