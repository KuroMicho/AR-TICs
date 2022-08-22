using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/KuroMicho");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://facebook.com");
    }

    public void OpenPDF()
    {
        Application.OpenURL(
            "https://drive.google.com/file/d/1momjIf9Gj1XOmE-x1fCgmcUxjAKx9pNC/view?usp=sharing"
        );
    }
}
