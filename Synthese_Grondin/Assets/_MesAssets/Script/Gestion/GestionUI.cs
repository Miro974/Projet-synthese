using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.SceneTemplate;

public class GestionUI : MonoBehaviour
{
    [SerializeField] private GameObject _menuPause = default;
    [SerializeField] private TextMeshProUGUI txtScore = default;
    [SerializeField] private TextMeshProUGUI txtTemps = default;
    [SerializeField] private TextMeshProUGUI txtAmmo = default;

    private bool _enPause = false;
    private int score = 0;
    private float tpsDepart = 0;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        score = 0;
        tpsDepart = Time.time;
        Time.timeScale = 1.0f;
        _enPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        GestionPause();
        UpdateScore();
        ChargerSceneFin();
        Timer();
        UpdateAmmo();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }

    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }

    private void UpdateScore()
    {
        txtScore.text = "Score : " + score.ToString();
    }

    // Méthode publique 
    public int getScore()
    {
        return score;
    }

    private void UpdateAmmo()
    {
        txtAmmo.text = "" + player.numMissile;
    }

    public void AjouterScore(int points)
    {
        score += points;
        UpdateScore();

        if ((score % 1000 == 0) && player.numMissile < 10)
        { 
            player.numMissile++;
        }
    }

    public void Timer()
    {
        float temps = Time.time - tpsDepart;
        txtTemps.text = "Temps: " + temps.ToString("f2");
    }

    public void ChargerSceneFin()
    {
        float temps = Time.time - tpsDepart;
        if (player.currentHealth < 1)
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetFloat("Temps", temps);
            PlayerPrefs.Save();

            StartCoroutine("FinPartie");
        }
    }

    IEnumerator FinPartie()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
