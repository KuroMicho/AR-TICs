using UnityEngine;
using UnityEngine.Android;

public class VoskResultText : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    void Start()
    {
        CheckPermission();
    }

    private void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    private void OnTranscriptionResult(string obj)
    {
        var result = new RecognitionResult(obj);
        for (int i = 0; i < result.Phrases.Length; i++)
        {
            if (i > 0)
            {
                if (result.Phrases[i].Text == "comando escuchar musica")
                {
                    GameObject.Find("AudioManager").GetComponent<AudioSource>().Play();
                    return;
                }

                if (result.Phrases[i].Text == "comando parar musica")
                {
                    GameObject.Find("AudioManager").GetComponent<AudioSource>().Stop();
                    return;
                }
                Debug.Log("No te entiendo maestro");
            }
        }
    }
}
