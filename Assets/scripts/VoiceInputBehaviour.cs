using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VoiceInputBehaviour : MonoBehaviour
{
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

    private bool Recording = false;

    private void Start()
    {
        MicSprite = MicRenderer.sprite;
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
                        ToggleRecording();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void ToggleRecording()
    {
        if (Recording)
        {
            MicRenderer.sprite = MicSprite;
            Recording = false;
        }
        else
        {
            int clip = Mathf.RoundToInt(Random.Range(0, 3));
            Listener.PlayOneShot(ListeningSounds[clip]);
            MicRenderer.sprite = RecordingSprite;
            Recording = true;
        }
    }
}
