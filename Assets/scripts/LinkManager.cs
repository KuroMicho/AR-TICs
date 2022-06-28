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
            "https://drive.google.com/file/d/1IjoqIqIuVw3FtulQgX-heB7JrbooNQHw/view?usp=sharing"
        );
    }
}
