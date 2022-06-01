using System.Collections;
using System.Collections.Generic;
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
        string namePDF = "Marcadores";
        Resources.Load<TextAsset>("PDFs/" + namePDF);
    }
}
