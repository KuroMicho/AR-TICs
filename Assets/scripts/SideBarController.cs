using UnityEngine;
using DG.Tweening;

public class SideBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform SideBarRect;

    private float RotationV = 0;
    private float RotationH = 0;
    private bool IsPressed = false;

    private bool AxisX = false;
    private bool AxisY = false;

    private void FixedUpdate()
    {
        if (IsPressed && AxisX)
        {
            RotationV += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
                new Vector3(RotationV * -45, 180, 0)
            );
        }

        if (IsPressed && AxisY)
        {
            RotationH += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
                new Vector3(0, (180 + RotationH) * 45, 0)
            );
        }
    }

    public void RotateV()
    {
        AxisX = true;
        AxisY = false;
        IsPressed = !IsPressed;
    }

    public void RotateH()
    {
        AxisX = false;
        AxisY = true;
        IsPressed = !IsPressed;
    }

    public void Reset()
    {
        IsPressed = false;
        RotationH = 0;
        RotationV = 0;

        // From sidebar to Model
        transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
            new Vector3(0, 180, 0)
        );
    }

    public void SideBarOpen()
    {
        SideBarRect.DOAnchorPosX(-50, 0.5f).SetEase(Ease.OutBack);
    }

    public void SideBarClose()
    {
        SideBarRect.DOAnchorPosX(50, 0.5f).SetEase(Ease.OutBack);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
