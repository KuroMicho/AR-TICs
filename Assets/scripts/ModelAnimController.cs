using UnityEngine;

public class ModelAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator ModelAnim;

    [SerializeField]
    private AudioSource ModelSound;

    private GameObject[] Sprites;

    private string Point;

    private void Start()
    {
        Sprites = GameObject.FindGameObjectsWithTag("Points");
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
                    case "PLAY":
                        foreach (var sprite in Sprites)
                            sprite.SetActive(false);
                        PlayAnim();
                        break;
                    case "STOP":
                        foreach (var sprite in Sprites)
                            sprite.SetActive(true);
                        StopAnim();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void PlayAnim()
    {
        ModelAnim.SetBool("Playing", true);
        ModelSound.PlayDelayed(0.5f);
    }

    public void StopAnim()
    {
        ModelAnim.SetBool("Playing", false);
        ModelSound.Stop();
    }
}
