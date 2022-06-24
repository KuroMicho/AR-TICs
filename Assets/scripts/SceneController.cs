using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator AudioFade;

    private void Awake()
    {
        Application.targetFrameRate = 30;
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

    public void OpenRetosScene()
    {
        StartCoroutine(LoadRetosScene());
    }
    IEnumerator LoadRetosScene()
    {
        AudioFade.SetTrigger("Start");
        GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("RetosScene");
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
}
