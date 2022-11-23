using UnityEngine;

public class ModelAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator[] ModelAnim;

    [SerializeField]
    private AudioSource[] ModelSound;

    private string Point;

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
                    case "PLAY_DRONE":
                        PlayAnim(0);
                        break;
                    case "STOP_DRONE":
                        StopAnim(0);
                        break;
                    case "PLAY_ROBOT":
                        PlayAnim(1);
                        break;
                    case "STOP_ROBOT":
                        StopAnim(1);
                        break;
                    case "PLAY_SMART":
                        PlayAnim(2);
                        break;
                    case "STOP_SMART":
                        StopAnim(2);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void PlayAnim(int num)
    {
        ModelAnim[num].SetBool("Playing", true);
        ModelSound[num].PlayDelayed(0.5f);
    }

    public void StopAnim(int num)
    {
        ModelAnim[num].SetBool("Playing", false);
        ModelSound[num].Stop();
    }
}
