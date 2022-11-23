using UnityEngine;

public class MenuARUpDownController : MonoBehaviour
{
    [SerializeField]
    private Animator MenuAnimator;

    private RectTransform Arrow;

    private void Start()
    {
        Arrow = GetComponent<RectTransform>();
    }

    private void Update()
    {
        bool IsOpen = MenuAnimator.GetBool("Show");

        if (IsOpen)
        {
            Arrow.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Arrow.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
