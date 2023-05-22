using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinPartie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScoreFinal = default;
    [SerializeField] private TextMeshProUGUI txtTpsFinal = default;
    [SerializeField] private TextMeshProUGUI txtFinPartie = default;

    private float temps;
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        txtScoreFinal.text = "Votre score : " + score.ToString();

        temps = PlayerPrefs.GetFloat("Temps");
        txtTpsFinal.text = "Votre temps : " + temps.ToString("f2") + "secondes";

        SequenceFinPartie();
    }

    private void SequenceFinPartie()
    { 
        txtFinPartie.gameObject.SetActive(true);
        StartCoroutine(FinPartieBlink());
    }

    IEnumerator FinPartieBlink()
    {
        while (true)
        {
            txtFinPartie.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            txtFinPartie.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }
}
