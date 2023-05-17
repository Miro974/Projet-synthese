using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Transform target = default;
    [SerializeField] private float distanceBetween;
    private float distance;
    private Player _player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _player = FindObjectOfType<Player>();
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        
        distance = Vector3.Distance(transform.position, target.transform.position);
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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
            Destroy(this.gameObject, 0f);
        }
    }
}
