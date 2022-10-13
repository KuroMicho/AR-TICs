using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousSceneController : MonoBehaviour
{
    private void Update()
    {
        if (SceneManager.GetSceneByName("QuizScene").isLoaded && Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<SceneController>().OpenPreviousScene();
            GameObject.Find("QuizManager").GetComponent<QuizManager>().Exit();
        }
    }
}
