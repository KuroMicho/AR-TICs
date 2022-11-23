using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Animator AudioFade;

    public static bool HelpShowed = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void OpenARScene()
    {
        StartCoroutine(LoadARScene());
    }

    IEnumerator LoadARScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ARScene");
    }

    public void OpenModulesScene()
    {
        StartCoroutine(LoadModulesScene());
    }

    IEnumerator LoadModulesScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ModulesScene");
    }

    public void OpenMainScene()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }

    public void OpenQuizScene()
    {
        StartCoroutine(LoadQuizScene());
    }

    IEnumerator LoadQuizScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("QuizScene");
    }

    public void OpenPreviousScene()
    {
        StartCoroutine(LoadPreviousScene());
    }

    IEnumerator LoadPreviousScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ModulesScene");
    }
}
