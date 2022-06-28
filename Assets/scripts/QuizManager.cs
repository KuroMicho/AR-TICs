using System.Collections;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TMP_Text HeaderText;
    public TMP_Text QuestionText;
    public TMP_Text NumberQuestionText;
    public TMP_Text CounterText;

    public TMP_Text PanelHeaderText;
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;
    public GameObject Achievement;

    public GameObject LayerParticles;

    public TMP_Text Answer1;
    public TMP_Text Answer2;
    public TMP_Text Answer3;
    public TMP_Text Answer4;

    public GameObject Option1;
    public GameObject Option2;

    public AudioSource AudioManager;
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioSource CounterSound;

    public AudioSource Notifier;
    public AudioClip[] WinnerSound;
    public AudioClip[] LoseSound;
    int Notification;

    const int MinRandom = 1;
    const int MaxRandom = 4;
    int CurrentQuestion = 1;
    const int LimitQuestion = 3;

    float TimeRemaining;
    public static bool CounterIsRunning = false;

    bool IsDone = false;
    public static bool IsFinished = false;

    int Score = 0;
    int TimePass = 0;

    int HighScore1 = 0;
    int BestTime1 = 0;

    int HighScore2 = 0;
    int BestTime2 = 0;

    int HighScore3 = 0;
    int BestTime3 = 0;

    int QuestionNumber = 0;
    int TempValue = 0;

    void Start()
    {
        IsFinished = false;

        if (ModuleManager.IsModule1)
        {
            LoadModule1();
        }
        if (ModuleManager.IsModule2)
        {
            LoadModule2();
        }
        if (ModuleManager.IsModule3)
        {
            LoadModule3();
        }

        HighScore1 = PlayerPrefs.GetInt("HighScore1", 0);
        BestTime1 = PlayerPrefs.GetInt("BestTime1", 75);

        HighScore2 = PlayerPrefs.GetInt("HighScore2", 0);
        BestTime2 = PlayerPrefs.GetInt("BestTime2", 75);

        HighScore3 = PlayerPrefs.GetInt("HighScore3", 0);
        BestTime3 = PlayerPrefs.GetInt("BestTime3", 75);
        NumberQuestionText.text = $"{CurrentQuestion}/{LimitQuestion}";
    }

    private void FixedUpdate()
    {
        if (CurrentQuestion > LimitQuestion)
        {
            if (!IsFinished)
            {
                StartCoroutine(GameOver());
                StopCoroutine(GameOver());
                IsFinished = true;
            }
        }

        if (CounterIsRunning)
        {
            TimeRemaining -= 1 * Time.deltaTime;

            if (TimeRemaining > 0)
            {
                DisplayTime(Mathf.RoundToInt(TimeRemaining));
            }
            else
            {
                TimeRemaining = 0;
                DisplayTime(Mathf.RoundToInt(TimeRemaining));
                IsDone = true;
                CounterIsRunning = false;
            }
        }

        if (IsDone)
        {
            CheckAnswer(false, 6);
            IsDone = false;
        }
    }

    IEnumerator GameOver()
    {
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(1.2f);

        CounterIsRunning = false;
        CounterSound.Stop();
        AudioManager.Stop();
        ScoreText.text = $"{Score}";

        if (ModuleManager.IsModule1)
        {
            if (Score > HighScore1)
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 3));
                Notifier.PlayOneShot(WinnerSound[Notification]);

                PlayerPrefs.SetInt("HighScore1", Score);
                HighScoreText.text = $"{Score}";
                PanelHeaderText.text = "Reto Completado!";

                Achievement.GetComponent<TMP_Text>().enabled = true;
                Achievement.GetComponent<AchievementAnimBehaviour>().MoveText();
                LayerParticles.GetComponent<Animator>().SetTrigger("Particles");
            }
            else
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 2));
                Notifier.PlayOneShot(LoseSound[Notification]);

                HighScoreText.text = $"{HighScore1}";
                PanelHeaderText.text = "Haria esto todo el dia!";
            }
        }

        if (ModuleManager.IsModule2)
        {
            if (Score > HighScore2)
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 3));
                Notifier.PlayOneShot(WinnerSound[Notification]);

                PlayerPrefs.SetInt("HighScore2", Score);
                HighScoreText.text = $"{Score}";
                PanelHeaderText.text = "Tutorial Completado!";

                Achievement.GetComponent<TMP_Text>().enabled = true;
                Achievement.GetComponent<AchievementAnimBehaviour>().MoveText();
                LayerParticles.GetComponent<Animator>().SetTrigger("Particles");
            }
            else
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 2));
                Notifier.PlayOneShot(LoseSound[Notification]);

                HighScoreText.text = $"{HighScore2}";
                PanelHeaderText.text = "La tercera es la vencida!";
            }
        }

        if (ModuleManager.IsModule3)
        {
            if (Score > HighScore3)
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 3));
                Notifier.PlayOneShot(WinnerSound[Notification]);

                PlayerPrefs.SetInt("HighScore3", Score);
                HighScoreText.text = $"{Score}";
                PanelHeaderText.text = "Siuuuuuuuuuuuuu!";

                Achievement.GetComponent<TMP_Text>().enabled = true;
                Achievement.GetComponent<AchievementAnimBehaviour>().MoveText();
                LayerParticles.GetComponent<Animator>().SetTrigger("Particles");
            }
            else
            {
                Notification = Mathf.RoundToInt(Random.Range(0, 2));
                Notifier.PlayOneShot(LoseSound[Notification]);

                HighScoreText.text = $"{HighScore3}";
                PanelHeaderText.text = "Aqui vamos de nuevo!";
            }
        }

        if (ModuleManager.IsModule1)
        {
            if (TimePass < BestTime1)
            {
                PlayerPrefs.SetInt("BestTime1", TimePass);
            }
        }

        if (ModuleManager.IsModule2)
        {
            if (TimePass < BestTime2)
            {
                PlayerPrefs.SetInt("BestTime2", TimePass);
            }
        }

        if (ModuleManager.IsModule3)
        {
            if (TimePass < BestTime3)
            {
                PlayerPrefs.SetInt("BestTime3", TimePass);
            }
        }
    }

    private void SkipQuestion()
    {
        CounterIsRunning = false;
        CurrentQuestion += 1;
        NumberQuestionText.text = $"{CurrentQuestion}/{LimitQuestion}";

        if (!IsFinished)
        {
            if (ModuleManager.IsModule1)
            {
                StartCoroutine(LoadQuestions1());
                StopCoroutine(LoadQuestions1());
            }
            ;
            if (ModuleManager.IsModule2)
            {
                StartCoroutine(LoadQuestions2());
                StopCoroutine(LoadQuestions2());
            }
            if (ModuleManager.IsModule3)
            {
                StartCoroutine(LoadQuestions3());
                StopCoroutine(LoadQuestions3());
            }
        }
    }

    int RandomNumber(int min, int max)
    {
        if (QuestionNumber < max)
        {
            TempValue = QuestionNumber + 1;
        }
        return TempValue;
        /*  for (int i =0; i < 10; i ++)
        {
            Value = Random.Range(min, max);  // 1
            if(Lista.Contains(Value))  // {1,2,3} contains 1
            {
                Lista.Remove(Value);  // {2,3}
                TempValue = Value;
                break;
            }
        }
        return TempValue; */
    }

    public void CheckAnswer(bool status, int answer)
    {
        if (status == true && answer == 1)
        {
            Score++;
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(CorrectSound);
            SkipQuestion();
        }

        if (status == true && answer == 2)
        {
            Score++;
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(CorrectSound);
            SkipQuestion();
        }

        if (status == true && answer == 3)
        {
            Score++;
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(CorrectSound);
            SkipQuestion();
        }

        if (status == true && answer == 4)
        {
            Score++;
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(CorrectSound);
            SkipQuestion();
        }

        if (status == false && answer != 6)
        {
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(WrongSound);
            SkipQuestion();
        }

        if (status == false && answer == 6)
        {
            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            SkipQuestion();
        }
    }

    public void SelectedOption(int option)
    {
        if (ModuleManager.IsModule1)
        {
            if (QuestionNumber == 1)
            {
                if (option == 1)
                    CheckAnswer(true, 1);
                if (option == 2)
                    CheckAnswer(false, 2);
                if (option == 3)
                    CheckAnswer(false, 3);
                if (option == 4)
                    CheckAnswer(false, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 2)
            {
                if (option == 3)
                    CheckAnswer(false, 3);
                if (option == 4)
                    CheckAnswer(true, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 3)
            {
                if (option == 1)
                    CheckAnswer(false, 1);
                if (option == 2)
                    CheckAnswer(false, 2);
                if (option == 3)
                    CheckAnswer(false, 3);
                if (option == 4)
                    CheckAnswer(true, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }
        }

        if (ModuleManager.IsModule2)
        {
            if (QuestionNumber == 1)
            {
                if (option == 3)
                    CheckAnswer(true, 3);
                if (option == 4)
                    CheckAnswer(false, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 2)
            {
                if (option == 1)
                    CheckAnswer(false, 1);
                if (option == 2)
                    CheckAnswer(false, 2);
                if (option == 3)
                    CheckAnswer(true, 3);
                if (option == 4)
                    CheckAnswer(false, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 3)
            {
                if (option == 3)
                    CheckAnswer(false, 3);
                if (option == 4)
                    CheckAnswer(true, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }
        }

        if (ModuleManager.IsModule3)
        {
            if (QuestionNumber == 1)
            {
                if (option == 1)
                    CheckAnswer(false, 1);
                if (option == 2)
                    CheckAnswer(false, 2);
                if (option == 3)
                    CheckAnswer(false, 3);
                if (option == 4)
                    CheckAnswer(true, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 2)
            {
                if (option == 3)
                    CheckAnswer(true, 3);
                if (option == 4)
                    CheckAnswer(false, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }

            if (QuestionNumber == 3)
            {
                if (option == 1)
                    CheckAnswer(false, 1);
                if (option == 2)
                    CheckAnswer(false, 2);
                if (option == 3)
                    CheckAnswer(true, 3);
                if (option == 4)
                    CheckAnswer(false, 4);
                if (option == 5)
                    CheckAnswer(false, 5);
                return;
            }
        }
    }

    void TransQuestion()
    {
        TimeRemaining = 25f;
        CounterSound.Stop();

        Option1.SetActive(true);
        Option2.SetActive(true);

        QuestionNumber = RandomNumber(MinRandom, MaxRandom);

        AudioManager.GetComponent<AudioSource>().volume = 0.5f;
    }

    IEnumerator LoadQuestions1()
    {
        if (!IsFinished)
        {
            yield return new WaitForSeconds(0.2f);
            TransQuestion();

            CounterIsRunning = true;
            CounterSound.PlayDelayed(0.7f);

            AudioManager.GetComponent<AudioSource>().volume = 0.7f;

            if (QuestionNumber == 1)
            {
                QuestionText.text =
                    "Cuales son los dos componentes principales de una computadora?";
                Answer1.text = "CPU y MotherBoard";
                Answer2.text = "Memoria y Monitor";
                Answer3.text = "CPU y Mouse";
                Answer4.text = "Se necesita una fuente";
            }

            if (QuestionNumber == 2)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text =
                    "Es correcto afirmar que la Memoria RAM solo almacena datos temporales?";
                Answer3.text = "Verdadero";
                Answer4.text = "Falso";
            }

            if (QuestionNumber == 3)
            {
                QuestionText.text =
                    "Seleccione la respuesta correcta 'La funcion principal es "
                    + "transformar los datos que envia el procesador, ademas cuenta con su propia memoria"
                    + " RAM y sistema de ventilacion'.";
                Answer1.text = "CPU";
                Answer2.text = "Disipador";
                Answer3.text = "SATA/SSD";
                Answer4.text = "Tarjeta de Video";
            }
        }
    }

    IEnumerator LoadQuestions2()
    {
        if (!IsFinished)
        {
            yield return new WaitForSeconds(1f);
            TransQuestion();

            CounterIsRunning = true;
            CounterSound.PlayDelayed(0.7f);

            AudioManager.GetComponent<AudioSource>().volume = 0.7f;

            if (QuestionNumber == 1)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text =
                    "Segun el enunciado, 'El GPS es un sistema "
                    + "de Posicionamiento Global, que permite determinar la posicion de la neogeocalizacion de alguien'";
                Answer3.text = "Verdadero";
                Answer4.text = "Falso";
            }

            if (QuestionNumber == 2)
            {
                QuestionText.text =
                    "Nombre del periferico que se utiliza para"
                    + " 'copiar' el contenido de un papel y automaticamente convertirlo en una imagen digital";
                Answer1.text = "Procesador";
                Answer2.text = "Sensor de luz";
                Answer3.text = "Escaner Digital";
                Answer4.text = "Pantalla Tactil";
            }

            if (QuestionNumber == 3)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text =
                    "Esta usted de acuerdo que la Memoria Interna y la Externa (MicroSD),"
                    + " juntas, superan la velocidad de la memoria RAM?";
                Answer3.text = "Verdadero";
                Answer4.text = "Falso";
            }
        }
    }

    IEnumerator LoadQuestions3()
    {
        if (!IsFinished)
        {
            yield return new WaitForSeconds(1f);
            TransQuestion();

            CounterIsRunning = true;
            CounterSound.PlayDelayed(0.7f);

            AudioManager.GetComponent<AudioSource>().volume = 0.7f;

            if (QuestionNumber == 1)
            {
                QuestionText.text = "Revoluciones industriales que se han dado en la humanidad?";
                Answer1.text = "Primera y Segunda";
                Answer2.text = "Tercera";
                Answer3.text = "Revolucion Informatica";
                Answer4.text = "Todas las anteriores";
            }

            if (QuestionNumber == 2)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text =
                    "La realidad aumentada inserta informacion digital en el mundo real?";
                Answer3.text = "Verdadero";
                Answer4.text = "Falso";
            }

            if (QuestionNumber == 3)
            {
                QuestionText.text = "Criptomoneda es:";
                Answer1.text = "Dinero";
                Answer2.text = "Criptografia";
                Answer3.text = "Moneda digital";
                Answer4.text = "App Descentralizada";
            }
        }
    }

    void DisplayTime(int CurrentTime)
    {
        CounterText.text = $"{CurrentTime}";
    }

    void LoadModule1()
    {
        HeaderText.text = "Ordenadores";
        StartCoroutine(LoadQuestions1());
        StopCoroutine(LoadQuestions1());
    }

    void LoadModule2()
    {
        HeaderText.text = "Moviles";
        StartCoroutine(LoadQuestions2());
        StopCoroutine(LoadQuestions2());
    }

    void LoadModule3()
    {
        HeaderText.text = "TIC 4.0";
        StartCoroutine(LoadQuestions3());
        StopCoroutine(LoadQuestions3());
    }
}
