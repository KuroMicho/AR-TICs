using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TMP_Text Header;
    public TMP_Text QuestionText;
    public TMP_Text NumberQuestionText;
    public TMP_Text Counter;
    public AudioSource AudioManager;
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioSource CounterSound;
    public AudioSource CounterSound2;
    public AudioSource CounterEnd;

    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    public GameObject SkipButton;


    const int MinRandom = 1;
    const int MaxRandom = 4;
    int CurrentQuestion = 1;
    float TimeRemaining;
    bool CounterIsRunning = false;
    const int LimitQuestion = 3;
    int Score = 0;

    //int Value;
    int QuestionNumber = 0;
    int TempValue = 0;
    //List<int> Lista = new List<int>() { 1, 2, 3 };

    void Start()
    {
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

        NumberQuestionText.text = $"{CurrentQuestion}/{LimitQuestion}";
    }

    void SkipQuestion()
    {
        CounterSound.Stop();

        if (ModuleManager.IsModule1)
        {
            StartCoroutine(LoadQuestions1());
        };
        if (ModuleManager.IsModule2) LoadQuestions2();
        if (ModuleManager.IsModule3) LoadQuestions3();

        CurrentQuestion += 1;
        NumberQuestionText.text = $"{CurrentQuestion}/{LimitQuestion}";
    }

    int RandomNumber(int min, int max)
    {
        if (QuestionNumber < max)
        {
            TempValue = QuestionNumber + 1;
        }
        return TempValue;
        //for (int i =0; i < 10; i ++)
        //{
        //   Value = Random.Range(min, max); // 1
        //    
        //    if(Lista.Contains(Value)) // {1,2,3} contains 1
        //    {
        //        Lista.Remove(Value); // {2,3}   
        //        TempValue = Value;
        //        break;
        //    }
        //    }

        //return TempValue;

    }


    public void CheckAnswer(bool status, int option)
    {
        if (status == true && option == 1)
        {
            Score++;
            AudioManager.PlayOneShot(CorrectSound);

            Option1.GetComponent<Button>().onClick.RemoveAllListeners();
            Option2.GetComponent<Button>().onClick.RemoveAllListeners();
            Option3.GetComponent<Button>().onClick.RemoveAllListeners();
            Option4.GetComponent<Button>().onClick.RemoveAllListeners();
            SkipButton.GetComponent<Button>().onClick.RemoveAllListeners();

            SkipQuestion();
        }

        if (status == true && option == 2)
        {
            Score++;
            AudioManager.PlayOneShot(CorrectSound);

            Option1.GetComponent<Button>().onClick.RemoveAllListeners();
            Option2.GetComponent<Button>().onClick.RemoveAllListeners();
            Option3.GetComponent<Button>().onClick.RemoveAllListeners();
            Option4.GetComponent<Button>().onClick.RemoveAllListeners();
            SkipButton.GetComponent<Button>().onClick.RemoveAllListeners();

            SkipQuestion();
        }

        if (status == true && option == 3)
        {
            Score++;
            AudioManager.PlayOneShot(CorrectSound);

            Option1.GetComponent<Button>().onClick.RemoveAllListeners();
            Option2.GetComponent<Button>().onClick.RemoveAllListeners();
            Option3.GetComponent<Button>().onClick.RemoveAllListeners();
            Option4.GetComponent<Button>().onClick.RemoveAllListeners();
            SkipButton.GetComponent<Button>().onClick.RemoveAllListeners();

            SkipQuestion();
        }

        if (status == true && option == 4)
        {
            Score++;
            AudioManager.PlayOneShot(CorrectSound);

            Option1.GetComponent<Button>().onClick.RemoveAllListeners();
            Option2.GetComponent<Button>().onClick.RemoveAllListeners();
            Option3.GetComponent<Button>().onClick.RemoveAllListeners();
            Option4.GetComponent<Button>().onClick.RemoveAllListeners();
            SkipButton.GetComponent<Button>().onClick.RemoveAllListeners();

            SkipQuestion();
        }

        if (status == false)
        {
            AudioManager.PlayOneShot(WrongSound);

            Option1.GetComponent<Button>().onClick.RemoveAllListeners();
            Option2.GetComponent<Button>().onClick.RemoveAllListeners();
            Option3.GetComponent<Button>().onClick.RemoveAllListeners();
            Option4.GetComponent<Button>().onClick.RemoveAllListeners();
            SkipButton.GetComponent<Button>().onClick.RemoveAllListeners();

            SkipQuestion();
        }

    }

    IEnumerator LoadQuestions1()
    {
        QuestionNumber = RandomNumber(MinRandom, MaxRandom);

        Option1.SetActive(true);
        Option2.SetActive(true);
        Option3.SetActive(true);
        Option4.SetActive(true);

        AudioManager.GetComponent<AudioSource>().volume = 0.5f;
        CounterSound.volume = 0.05f;

        yield return new WaitForSeconds(1f);

        TimeRemaining = 25f;
        CounterIsRunning = true;

        AudioManager.GetComponent<AudioSource>().volume = 0.7f;
        CounterSound.volume = 0.2f;
        CounterSound.Play();

        if (QuestionNumber == 1)
        {
            QuestionText.text = "¿Cuales son los dos componentes principales de una computadora?";
            Option1.transform.GetChild(0).GetComponent<TMP_Text>().text = "CPU y MotherBoard.";
            Option2.transform.GetChild(0).GetComponent<TMP_Text>().text = "Memoria y Monitor.";
            Option3.transform.GetChild(0).GetComponent<TMP_Text>().text = "CPU y Mouse.";
            Option4.transform.GetChild(0).GetComponent<TMP_Text>().text = "Se necesita una fuente.";

            Option1.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(true, 1));
            Option2.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 2));
            Option3.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 3));
            Option4.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 4));
            SkipButton.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 5));
        }

        if (QuestionNumber == 2)
        {
            QuestionText.text = "¿Es correcto afirmar que la Memoria RAM solo almacena datos temporales?";
            Option1.SetActive(false);
            Option2.SetActive(false);
            Option3.transform.GetChild(0).GetComponent<TMP_Text>().text = "Verdadero.";
            Option4.transform.GetChild(0).GetComponent<TMP_Text>().text = "Falso.";
            Option3.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 3));
            Option4.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(true, 4));
            SkipButton.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 5));

        }

        if (QuestionNumber == 3)
        {
            Debug.Log("Here");
            QuestionText.text = "Seleccione la respuesta correcta 'La funcion principal es " +
                "transformar los datos que envia el procesador, ademas cuenta con su propia memoria" +
                " RAM y sistema de ventilacion'.";
            Option1.transform.GetChild(0).GetComponent<TMP_Text>().text = "CPU.";
            Option2.transform.GetChild(0).GetComponent<TMP_Text>().text = "Disipador.";
            Option3.transform.GetChild(0).GetComponent<TMP_Text>().text = "SATA/SSD.";
            Option4.transform.GetChild(0).GetComponent<TMP_Text>().text = "Tarjeta de Video.";

            Option1.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 1));
            Option2.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 2));
            Option3.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(true, 3));
            Option4.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 4));
            SkipButton.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(false, 5));

        }
    }

    public void LoadQuestions2()
    {
        RandomNumber(MinRandom, MaxRandom);

        if (QuestionNumber == 1)
        {
            QuestionText.text = "Question 1";
        }

        if (QuestionNumber == 2)
        {
            QuestionText.text = "Question 2";
        }

        if (QuestionNumber == 3)
        {
            QuestionText.text = "Question 3";
        }
    }

    public void LoadQuestions3()
    {
        RandomNumber(MinRandom, MaxRandom);

        if (QuestionNumber == 1)
        {
            QuestionText.text = "Question 1";
        }

        if (QuestionNumber == 2)
        {
            QuestionText.text = "Question 2";
        }

        if (QuestionNumber == 3)
        {
            QuestionText.text = "Question 3";
        }
    }

    private void Update()
    {
        if (CurrentQuestion > LimitQuestion)
        {
            Option1.GetComponent<Button>().interactable = false;
            Option2.GetComponent<Button>().interactable = false;
            Option3.GetComponent<Button>().interactable = false;
            Option4.GetComponent<Button>().interactable = false;
            GameObject.Find("Skip").GetComponent<Button>().interactable = false;
        }

        if (CounterIsRunning)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= 1 * Time.deltaTime;
                DisplayTime(Mathf.RoundToInt(TimeRemaining));
            }

           
            if (TimeRemaining < 1)
            {
                CounterSound2.Stop();
                CounterEnd.Play();
            
                Debug.Log("Time has run out!");
                
                TimeRemaining = 0;
                DisplayTime(Mathf.RoundToInt(TimeRemaining));
                CounterIsRunning = false;
            }
        }
        
    }

    void DisplayTime(int CurrentTime)
    {
        if (CurrentTime >= 1 && CurrentTime <= 9)
        {
            CounterSound.Stop();
            CounterSound2.Play();
        }

        Counter.text = $"{CurrentTime}";
    }

    void LoadModule1()
    {
        Header.text = "Ordenadores";
        StartCoroutine(LoadQuestions1());
    }

    void LoadModule2()
    {
        Header.text = "Moviles";
        LoadQuestions2();
    }

    void LoadModule3()
    {
        Header.text = "TIC 4.0";
        LoadQuestions3();
    }
}
