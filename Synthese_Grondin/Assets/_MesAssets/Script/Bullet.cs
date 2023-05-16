using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.y > 8f)
        { 
            Destroy(this.gameObject);
        }
    }
}
