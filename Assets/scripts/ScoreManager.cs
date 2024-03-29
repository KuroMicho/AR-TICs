using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text BestTime1;

    [SerializeField]
    private TMP_Text HighScoreText1;

    [SerializeField]
    private TMP_Text Attempts1;

    [SerializeField]
    private TMP_Text BestTime2;

    [SerializeField]
    private TMP_Text HighScoreText2;

    [SerializeField]
    private TMP_Text Attempts2;

    [SerializeField]
    private TMP_Text BestTime3;

    [SerializeField]
    private TMP_Text HighScoreText3;

    [SerializeField]
    private TMP_Text Attempts3;

    private void Start()
    {
        BestTime1.text = PlayerPrefs.GetInt("BestTime1", 250).ToString() + " Segundos";
        HighScoreText1.text = "Mejor Puntuación: " + PlayerPrefs.GetInt("HighScore1", 0).ToString();
        Attempts1.text = "Número de Intentos: " + PlayerPrefs.GetInt("Attempts1", 0).ToString();

        BestTime2.text = PlayerPrefs.GetInt("BestTime2", 250) + " Segundos";
        HighScoreText2.text = "Mejor Puntuación: " + PlayerPrefs.GetInt("HighScore2", 0).ToString();
        Attempts2.text = "Número de Intentos: " + PlayerPrefs.GetInt("Attempts2", 0).ToString();

        BestTime3.text = PlayerPrefs.GetInt("BestTime3", 250).ToString() + " Segundos";
        HighScoreText3.text = "Mejor Puntuación: " + PlayerPrefs.GetInt("HighScore3", 0).ToString();
        Attempts3.text = "Número de Intentos: " + PlayerPrefs.GetInt("Attempts3", 0).ToString();
    }
}
