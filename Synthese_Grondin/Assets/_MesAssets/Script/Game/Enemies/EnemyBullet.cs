using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
