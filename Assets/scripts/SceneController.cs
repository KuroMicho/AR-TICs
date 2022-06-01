using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OpenARScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void OpenRetosScene()
    {
        SceneManager.LoadScene("RetosScene");
    }

    public void OpenMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenQuizScene()
    {
        SceneManager.LoadScene("QuizScene");
    }
}
