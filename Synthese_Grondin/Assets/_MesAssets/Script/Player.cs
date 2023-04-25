using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        MouvementJoueur();
    }

    private void MouvementJoueur()
    {
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(posX, posY, 0);

        transform.Translate(direction * Time.deltaTime * _vitesse);
    }
}
