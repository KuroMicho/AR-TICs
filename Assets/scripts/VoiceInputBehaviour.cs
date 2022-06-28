using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VoiceInputBehaviour : MonoBehaviour
{
    public VoskSpeechToText VoskSpeechToText;

    private string Point;

    [SerializeField]
    private AudioSource Listener;

    [SerializeField]
    private AudioClip[] ListeningSounds;

    [SerializeField]
    private SpriteRenderer MicRenderer;

    [SerializeField]
    private Sprite RecordingSprite;

    private Sprite MicSprite;

    private bool Recording = true;

    private void Start()
    {
        MicSprite = MicRenderer.sprite;
        StartRecording();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray RayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            if (Physics.Raycast(RayTouch, out Hit))
            {
                Point = Hit.transform.name;

                switch (Point)
                {
                    case "MIC":
                        StartRecording();
                        VoskSpeechToText.ToggleRecording();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void StartRecording()
    {
        if (Recording)
        {
            int clip = Mathf.RoundToInt(Random.Range(0, 3));
            Listener.PlayOneShot(ListeningSounds[clip]);
            MicRenderer.sprite = RecordingSprite;
            Recording = false;
        }
        else
        {
            MicRenderer.sprite = MicSprite;
            Recording = true;
        }
    }
}
