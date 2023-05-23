using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 0.5f;
    [SerializeField] private int enemyLife = 1;

    [SerializeField] private int points = 200;

    private GestionUI gestionUI;

    //private SpawnManager spawnManager;
    private Player _player;

    void Start()
    {
        gestionUI = FindObjectOfType<GestionUI>().GetComponent<GestionUI>();
        //spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed);
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.transform.GetComponent<Player>();
            _player.Damage();
            Destroy(gameObject, 0f);
        }
        else if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            enemyLife--;
            if (enemyLife < 1)
            {
                Destroy(gameObject, 0f);
                gestionUI.AjouterScore(points);
                //spawnManager.turretHere = false;
            }
        }
        else if (other.tag == "Missile")
        {
            enemyLife = 0;
            if (enemyLife < 1)
            {
                Destroy(this.gameObject, 0f);
                gestionUI.AjouterScore(points);
            }
        }
    }
}
