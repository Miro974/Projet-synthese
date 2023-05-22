using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

    public void ChargerSceneTuto()
    {
        SceneManager.LoadScene(3);
    }

    public void ChargerJeu()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangerScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
