using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/KuroMicho");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://facebook.com/profile.php?id=100088083484663");
    }

    public void OpenPDF()
    {
        Application.OpenURL(
            "https://drive.google.com/file/d/1momjIf9Gj1XOmE-x1fCgmcUxjAKx9pNC/view?usp=sharing"
        );
    }
}
