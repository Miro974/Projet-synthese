using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _vitesse = 10f;

    private Vector3 playerPosDepart;
    private Vector3 mousePos;
    public bool turned = false;



    void Start()
    {
        playerPosDepart = new Vector3 (-7.2f, -3.52f, 0f);
        transform.position = playerPosDepart;
    }
    void Update()
    {
        MouvementJoueur();
        RotationObjet();
    }

    private void RotationObjet()
    {
        mousePos = Input.mousePosition;

        if (mousePos.x < 1)
        {
            Debug.Log("in IF");
            transform.rotation = Quaternion.Euler(new Vector3(0f, -190f, 0f));
            turned = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            turned = false;
        }
    }

    private void MouvementJoueur()
    {
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(posX, posY, 0);

        transform.Translate(direction * Time.deltaTime * _vitesse);
    }
}
