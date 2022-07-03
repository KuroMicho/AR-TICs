using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    #region Text
    [SerializeField]
    private TMP_Text HeaderText;

    [SerializeField]
    private TMP_Text QuestionText;

    [SerializeField]
    private TMP_Text NumberQuestionText;

    [SerializeField]
    private TMP_Text CounterText;

    [SerializeField]
    private TMP_Text PanelHeaderText;

    [SerializeField]
    private TMP_Text ScoreText;

    [SerializeField]
    private TMP_Text HighScoreText;

    [SerializeField]
    private TMP_Text Answer1;

    [SerializeField]
    private TMP_Text Answer2;

    [SerializeField]
    private TMP_Text Answer3;

    [SerializeField]
    private TMP_Text Answer4;
    #endregion

    #region Question Image
    [SerializeField]
    private Image QuestionImage;

    [SerializeField]
    private Sprite Module1Question6Image;

    [SerializeField]
    private Sprite Module1Question8Image;

    [SerializeField]
    private Sprite Module1Question10Image;

    [SerializeField]
    private Sprite Module2Question4Image;

    [SerializeField]
    private Sprite Module2Question5Image;

    [SerializeField]
    private Sprite Module2Question6Image;

    [SerializeField]
    private Sprite Module3Question1Image;

    [SerializeField]
    private Sprite Module3Question3Image;

    [SerializeField]
    private Sprite Module3Question9Image;
    #endregion

    #region GameObjects and Anims
    [SerializeField]
    private GameObject Panel;

    [SerializeField]
    private GameObject Achievement;

    [SerializeField]
    private GameObject LayerParticles;

    [SerializeField]
    private GameObject Bubble;
    #endregion

    #region First Two Buttons
    [SerializeField]
    private GameObject Option1;

    [SerializeField]
    private GameObject Option2;
    #endregion

    #region Audio
    [SerializeField]
    private AudioSource AudioManager;

    [SerializeField]
    private AudioClip CorrectSound;

    [SerializeField]
    private AudioClip WrongSound;

    [SerializeField]
    private AudioSource CounterSound;

    [SerializeField]
    private AudioSource Notifier;

    [SerializeField]
    private AudioClip[] WinnerSound;

    [SerializeField]
    private AudioClip[] LoseSound;
    #endregion

    private int Notification;

    private int CurrentQuestion = 1;
    private const int LimitQuestion = 10;

    private float TimeRemaining;
    public static bool CounterIsRunning = false;

    private bool IsDone = false;
    public static bool IsFinished = false;

    private int Score = 0;
    private int TimePass = 0;
    private int Strike = 0;

    private int HighScore1 = 0;
    private int BestTime1 = 0;

    private int HighScore2 = 0;
    private int BestTime2 = 0;

    private int HighScore3 = 0;
    private int BestTime3 = 0;

    private void Start()
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
        BestTime1 = PlayerPrefs.GetInt("BestTime1", 250);

        HighScore2 = PlayerPrefs.GetInt("HighScore2", 0);
        BestTime2 = PlayerPrefs.GetInt("BestTime2", 250);

        HighScore3 = PlayerPrefs.GetInt("HighScore3", 0);
        BestTime3 = PlayerPrefs.GetInt("BestTime3", 250);
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
        Panel.SetActive(true);
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

    // 1-4 options, 5 omit, 6 timer end
    public void CheckAnswer(bool status, int answer)
    {
        if (status == true && answer != 5)
        {
            Strike++;

            if (Strike >= 2)
            {
                Score = Score + 2;
                Bubble.GetComponent<TMP_Text>().text = "+2";
                Bubble.GetComponent<BubbleAnimBehaviour>().Up();
            }
            else
            {
                Score++;
                Bubble.GetComponent<TMP_Text>().text = "+1";
                Bubble.GetComponent<BubbleAnimBehaviour>().Up();
            }

            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(CorrectSound);
            SkipQuestion();
        }

        if (status == false && answer != 6)
        {
            Strike = 0;
            if (answer == 5)
            {
                Score--;
                Bubble.GetComponent<TMP_Text>().text = "-1";
                Bubble.GetComponent<BubbleAnimBehaviour>().Up();
            }
            else
            {
                Score = Score - 2;
                Bubble.GetComponent<TMP_Text>().text = "-2";
                Bubble.GetComponent<BubbleAnimBehaviour>().Up();
            }

            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            AudioManager.PlayOneShot(WrongSound);
            SkipQuestion();
        }

        if (status == false && answer == 6)
        {
            Strike = 0;
            Score = Score - 3;
            Bubble.GetComponent<TMP_Text>().text = "-3";
            Bubble.GetComponent<BubbleAnimBehaviour>().Up();

            TimePass += (25 - Mathf.RoundToInt(TimeRemaining));
            SkipQuestion();
        }
    }

    private void Answer(int opt, int answer)
    {
        int AnswerCorrect = answer;

        if (opt == AnswerCorrect)
            CheckAnswer(true, AnswerCorrect);

        if (opt != AnswerCorrect && opt != 5)
            CheckAnswer(false, 0);

        if (opt == 5)
            CheckAnswer(false, 5);
    }

    public void SelectedOption(int option)
    {
        int optionSelected = option;
        int questionAnswer;

        if (ModuleManager.IsModule1)
        {
            if (CurrentQuestion == 1)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 2)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 3)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 4)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 5)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 6)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 7)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 8)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 9)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 10)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }
        }

        if (ModuleManager.IsModule2)
        {
            if (CurrentQuestion == 1)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 2)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 3)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 4)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 5)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 6)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 7)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 8)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 9)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }

            if (CurrentQuestion == 10)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }
        }

        if (ModuleManager.IsModule3)
        {
            if (CurrentQuestion == 1)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 2)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 3)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 4)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 5)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 6)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 7)
            {
                questionAnswer = 4;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 8)
            {
                questionAnswer = 1;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 9)
            {
                questionAnswer = 2;
                Answer(optionSelected, questionAnswer);
                return;
            }
            if (CurrentQuestion == 10)
            {
                questionAnswer = 3;
                Answer(optionSelected, questionAnswer);
                return;
            }
        }
    }

    private string AlignmentText(string question)
    {
        if (question.Length <= 100)
        {
            QuestionText.alignment = TextAlignmentOptions.Center;
        }
        else
        {
            QuestionText.alignment = TextAlignmentOptions.Left;
        }

        return question;
    }

    private void TransQuestion()
    {
        TimeRemaining = 25f;
        CounterSound.Stop();

        Option1.SetActive(true);
        Option2.SetActive(true);

        QuestionImage.color = new Color(255, 255, 255, 0);

        AudioManager.GetComponent<AudioSource>().volume = 0.2f;
    }

    IEnumerator LoadQuestions1()
    {
        if (!IsFinished)
        {
            yield return new WaitForSeconds(0.2f);
            TransQuestion();

            CounterIsRunning = true;
            CounterSound.PlayDelayed(0.7f);

            AudioManager.GetComponent<AudioSource>().volume = 0.5f;

            if (CurrentQuestion == 1)
            {
                QuestionText.text = AlignmentText(
                    "Una de las caracteristicas del CPU de una laptop, es"
                );
                Answer1.text = "Consumen menos energia y no tienen refrigeracion";
                Answer2.text = "Consumen menos energia y generan menos calor"; // Correct
                Answer3.text = "Consumen mas energia y generan menos calor";
                Answer4.text = "Consumen mas energia y usan dispositivos de refrigeracion";
            }

            if (CurrentQuestion == 2)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text = AlignmentText(
                    "Es correcto afirmar que la memoria RAM permite almacenar temporalmente informacion a una velocidad elevada, permitiendo que el dispositivo computarizado funcione y realice tareas automatizadas?"
                );
                Answer3.text = "Verdadero"; // Correct
                Answer4.text = "Falso";
            }

            if (CurrentQuestion == 3)
            {
                QuestionText.text = AlignmentText(
                    "Seleccione la respuesta correcta 'Esta disenada especificamente para realizar los calculos matematicos y geometricos complejos que son necesarios para la representacion de graficos'."
                );
                Answer1.text = "CPU";
                Answer2.text = "BIOS";
                Answer3.text = "M.2";
                Answer4.text = "Tarjeta de video"; // Correct
            }

            if (CurrentQuestion == 4)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text = AlignmentText(
                    "Los SSD utilizan memorias flash y ofrecen latencias menores (mayor velocidad de escritura/lectura) que las de un disco duro HDD?"
                );
                Answer3.text = "Verdadero"; // Correct
                Answer4.text = "Falso";
            }

            if (CurrentQuestion == 5)
            {
                QuestionText.alignment = TextAlignmentOptions.Center;
                QuestionText.text = AlignmentText(
                    "En lo referente a la placa base, de que derivan las siglas PCB?"
                );
                Answer1.text = "Partido Comunista Britanico";
                Answer2.text = "Programa Central del Bus";
                Answer3.text = "Placa de Circuito Impreso"; // Correct
                Answer4.text = "Puerto Conector Bilateral";
            }

            if (CurrentQuestion == 6)
            {
                QuestionText.text = AlignmentText(
                    "Puedes reconocer el nombre de esta ranura o sitio que hace parte de la placa base?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module1Question6Image;
                Answer1.text = "Socket"; // Correct
                Answer2.text = "Microprocesador";
                Answer3.text = "Ranura PCIe";
                Answer4.text = "Ninguna es correcta";
            }

            if (CurrentQuestion == 7)
            {
                QuestionText.text = AlignmentText(
                    "La fuente de poder o de alimentacion solamente se encarga de transportar la energia desde la red electrica al equipo"
                );
                Option1.SetActive(false);
                Option2.SetActive(false);
                Answer3.text = "Verdadero";
                Answer4.text = "Falso"; // Correct
            }

            if (CurrentQuestion == 8)
            {
                QuestionText.text = AlignmentText(
                    "Identifique la fuente de poder que observa e identifique la fuente de poder que observa en la imagen"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module1Question8Image;
                Answer1.text = "Semimodular";
                Answer2.text = "No Modular";
                Answer3.text = "Modular"; // Correct
                Answer4.text = "Fuente SFX (Factor de forma pequeno)";
            }

            if (CurrentQuestion == 9)
            {
                QuestionText.text = AlignmentText(
                    "El procesador que sea (AMD o Intel de ultima generacion) funciona para cualquier placa madre?"
                );
                Option1.SetActive(false);
                Option2.SetActive(false);
                Answer3.text = "Verdadero";
                Answer4.text = "Falso"; // Correct
            }

            if (CurrentQuestion == 10)
            {
                QuestionText.text = AlignmentText(
                    "Cual de estos dispositivos se puede adaptar en una interfaz M.2?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module1Question10Image;
                Answer1.text = "Una unidad SSD NVMe"; // Correct
                Answer2.text = "Un disco HDD";
                Answer3.text = "Una lectora";
                Answer4.text = "Una unidad de memoria";
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

            AudioManager.GetComponent<AudioSource>().volume = 0.5f;

            if (CurrentQuestion == 1)
            {
                QuestionText.text = AlignmentText(
                    "En lo referente a un telefono inteligente, las siglas SoC, que significan?"
                );
                Answer1.text = "System Onboard Control";
                Answer2.text = "System On Chip"; // Correct
                Answer3.text = "Security Center Operation";
                Answer4.text = "Status Operation Control";
            }

            if (CurrentQuestion == 2)
            {
                QuestionText.text = AlignmentText(
                    "Si el SoC no dispone de un chip dedicado para la decodificacion de video, entonces la  _____  puede encargarse de cumplir ese proposito y manejar videos de alta resolucion."
                );
                Answer1.text = "RAM";
                Answer2.text = "ROM";
                Answer3.text = "GPU"; // Correct
                Answer4.text = "CPU";
            }

            if (CurrentQuestion == 3)
            {
                QuestionText.text = AlignmentText(
                    "Se puede consumir grandes cantidades de recursos en almacenamiento de graficos (texturas, modelos 3D) y el sonido. Para evitar esto, la mayoria de los smartphones necesitan"
                );
                Answer1.text = "CPU con bastantes nucleos";
                Answer2.text = "RAM entre 1GB y 2GB"; // Correct
                Answer3.text = "GPU mas potente";
                Answer4.text = "Ser de alta gama";
            }

            if (CurrentQuestion == 4)
            {
                QuestionText.text = AlignmentText(
                    "Cual es la diferencia de las derivadas tecnologias OLED, AMOLED y Super AMOLED para pantallas de smartphones en comparacion con LCD?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module2Question4Image;
                Answer1.text = "Mejor autonomia y ahorro de bateria";
                Answer2.text = "Eliminacion de luz de fondo";
                Answer3.text = "Pantalla llamativa, brillante y saturada";
                Answer4.text = "Todas las anteriores"; // Correct
            }

            if (CurrentQuestion == 5)
            {
                QuestionText.text = AlignmentText(
                    "Entre las diferentes variantes de LCD, cual de las siguientes no hace parte de este tipo de tecnologia de pantalla?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module2Question5Image;
                Answer1.text = "LOL (Line Organic Layer), resalte de colores y fidelidad"; // Correct
                Answer2.text = "LED (Light-Emitting Diode). La mayoria de pantallas en LCD son LED";
                Answer3.text = "IPS (In-Plane Switching). Es una pantalla LED modificada";
                Answer4.text = "TFT (Thin- Film Transistor). Las anteriores se basan en esta";
            }

            if (CurrentQuestion == 6)
            {
                QuestionText.text = AlignmentText(
                    "El bloque optico y el sensor son los dos elementos de la camara que determinan su calidad, entonces a mayor tamano de sensor y de optica conseguiremos una mayor calidad en la camara del dispositivo movil?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module2Question6Image;
                Answer1.text = "No, se trata solo de megapixeles";
                Answer2.text = "Si, entre mayor luz absorba mejor sera la foto";
                Answer3.text = "No, solo importa el software de post-procesado de la imagen";
                Answer4.text = "Si, pero hay que tener en cuenta caracteristicas adicionales"; // Correct
            }
            if (CurrentQuestion == 7)
            {
                Option1.SetActive(false);
                Option2.SetActive(false);
                QuestionText.text = AlignmentText(
                    "Se puede afirmar que, 'El GPS es un sistema de posicionamiento global, que permite determinar la posicion de geolocalizacion de alguien'"
                );
                Answer3.text = "Verdadero"; //Correct
                Answer4.text = "Falso";
            }

            if (CurrentQuestion == 8)
            {
                QuestionText.text = AlignmentText(
                    "El giroscopio es un instrumento que sirve de orientacion y nos permite conocer la direccion del smartphone en relacion a los polos magneticos de la tierra o al norte geografico. La definicion es correcta?"
                );
                Answer1.text = "La definicion corresponde a 'Brujula digital'"; // Correct
                Answer2.text = "La definicion corresponde a 'Sensor de proximidad'";
                Answer3.text = "La definicion corresponde a 'Acelerometro'";
                Answer4.text = "Es correcto";
            }

            if (CurrentQuestion == 9)
            {
                QuestionText.text = AlignmentText(
                    "Que tecnologia permite que los filtros de Snapchat e Instagram sean capaces de crear especie de mascara 3D para interpretar los movimientos del usuario, incluso cuando nos movemos o cambiamos de posicion"
                );
                Answer1.text = "Algoritmos de inteligencia artificial";
                Answer2.text = "Sistema de reconocimiento facial";
                Answer3.text = "Realidad aumentada";
                Answer4.text = "Todas las anteriores"; // Correct
            }

            if (CurrentQuestion == 10)
            {
                QuestionText.text = AlignmentText(
                    "En dispositivos Android (Sistema operativo de Google) que requerimiento es indispensable para poder utilizar 'Realidad aumentada'?"
                );
                Answer1.text = "Una camara decente";
                Answer2.text = "Software ARCore y un hardware en especifico"; // Correct
                Answer3.text = "Sensores como acelerometros y giroscopio";
                Answer4.text = "Procesador y GPU lo suficientemente potente";
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

            AudioManager.GetComponent<AudioSource>().volume = 0.5f;

            if (CurrentQuestion == 1)
            {
                QuestionText.text = AlignmentText(
                    "Cual de las siguientes es una regla de seguridad que debes seguir al operar un dron?"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module3Question1Image;
                Answer1.text =
                    "Mantener tu dron por encima de los 100 metros cuando vueles directamente sobre personas";
                Answer2.text = "Debes poder ver su dron con sus propios ojos en todo momento"; // Correct
                Answer3.text =
                    "Si vuelas dos drones al mismo tiempo, debes tener el control de ambos";
                Answer4.text = "Todo lo anterior";
            }

            if (CurrentQuestion == 2)
            {
                QuestionText.text = AlignmentText(
                    "Que hacer si se pierde contacto visual con el dron y no se logra recuperar el mismo?"
                );
                Answer1.text =
                    "Verificar de acuerdo a la planificacion del vuelo donde puede estar dandole indicacion de retorno a base"; // Correct
                Answer2.text = "Revisar la planificacion del vuelo y rezar para poder encontrarlo";
                Answer3.text = "Nada, buscar a ver donde puede haber caido";
                Answer4.text = "Ninguna de las anteriores";
            }

            if (CurrentQuestion == 3)
            {
                QuestionText.text = AlignmentText(
                    "Al estar inmersos en un entorno de escenas y objetos simulados o realidad virtual"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module3Question3Image;
                Answer1.text = "El cerebro tiene una menor capacidad de asimilar informacion";
                Answer2.text = "El cerebro tiene una mayor capacidad de asimilar informacion"; // Correct
                Answer3.text =
                    "El cerebro no tiene contacto con la capacidad de asimilar informacion";
                Answer4.text = "Ninguna de las anteriores";
            }

            if (CurrentQuestion == 4)
            {
                QuestionText.text = AlignmentText(
                    "Cuales son las partes fundamentales por las que esta compuesto un robot, para que pueda realizar procesos industriales"
                );
                Answer1.text = "Electronica, Motores, Programacion, Energia, Mecanica"; // Correct
                Answer2.text = "Robotica y Programacion";
                Answer3.text = "Electromecanica, Motores, Programacion, Energia, Quimica";
                Answer4.text = "Motores, Programacion, Energia";
            }

            if (CurrentQuestion == 5)
            {
                QuestionText.text = AlignmentText(
                    "El proceso de  _____  en un robot consiste en introducir en su sistema de control las instrucciones necesarias para que desempene las tareas para las que ha sido disenados"
                );
                Answer1.text = "Diseno";
                Answer2.text = "Programacion"; // Correct
                Answer3.text = "Aprendizaje";
                Answer4.text = "Ensamble";
            }

            if (CurrentQuestion == 6)
            {
                QuestionText.text = AlignmentText("El principal objetivo de la I.A. es");
                Answer1.text = "Hacer todas las tareas que realiza el ser humano";
                Answer2.text = "Conquistar el mundo y predecir el futuro";
                Answer3.text = "Emular la forma en que el ser humano predice y toma decisiones"; // Correct
                Answer4.text =
                    "Crear seres superiores a los humanos que tomen decisiones mas acertadas";
            }

            if (CurrentQuestion == 7)
            {
                QuestionText.text = AlignmentText(
                    "Un asistente virtual de voz se basa en el reconocimiento de palabras y frases haciendo uso del lenguaje natural, un ejemplo de este asistente es"
                );
                Answer1.text = "Tay I.A. de Microsoft";
                Answer2.text = "Alpha Go de Deep Mind";
                Answer3.text = "Watsson de IBM";
                Answer4.text = "Alexa de Amazon"; // Correct
            }

            if (CurrentQuestion == 8)
            {
                QuestionText.text = AlignmentText(
                    "En el proceso de aprendizaje (learning) del agente hay tres elementos que se requieren. Cuales son?"
                );
                Answer1.text = "Entrada - Modelo de Entrenamiento - Salida"; // Correct
                Answer2.text = "Informacion - Proceso - Resultado";
                Answer3.text = "Entrada - Proceso - Salida";
                Answer4.text = "Entrada - Retroalimentacion - Proceso";
            }
            if (CurrentQuestion == 9)
            {
                QuestionText.text = AlignmentText(
                    "La red inteligente gestiona la demanda de electricidad de forma sostenible, fiable y economica, basada en una infraestructura avanzada, con una interconexion de"
                );
                QuestionImage.color = new Color(255, 255, 255, 255);
                QuestionImage.sprite = Module3Question9Image;
                Answer1.text = "Energia y TI";
                Answer2.text = "Energia, TI y comunicacion";
                Answer3.text = "TI y comunicacion";
                Answer4.text = "Energia y mecatronica"; // Correct
            }

            if (CurrentQuestion == 10)
            {
                QuestionText.text = AlignmentText(
                    "Los coches autonomos prometen revolucionar el sistema de movilidad urbana a nivel mundial, que beneficio se espera de estos vehiculos en la actualidad?"
                );
                Answer1.text = "Reduccion de los accidentes de trafico";
                Answer2.text = "Movilidad mas sostenible con el medioambiente";
                Answer3.text = "La primera y segunda son correctas"; // Correct
                Answer4.text = "Precio elevado";
            }
        }
    }

    void DisplayTime(int CurrentTime)
    {
        CounterText.text = $"{CurrentTime}";
    }

    void LoadModule1()
    {
        HeaderText.text = "Computacion";
        StartCoroutine(LoadQuestions1());
        StopCoroutine(LoadQuestions1());
    }

    void LoadModule2()
    {
        HeaderText.text = "Movil";
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
