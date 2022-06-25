using UnityEngine;
using DG.Tweening;

public class SideBarController : MonoBehaviour
{
    [SerializeField]
    private RectTransform SideBarRect;

    private float RotationV = 0f;
    private float RotationH = 0f;
    private bool IsPressed = false;

    private bool AxisX = false;
    private bool AxisY = false;

    private void FixedUpdate()
    {
        if (IsPressed && AxisX)
        {
            RotationV += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
                new Vector3(RotationV * -45, 180f, 0f)
            );
        }

        if (IsPressed && AxisY)
        {
            RotationH += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
                new Vector3(0, RotationH * -45, 0f)
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
        RotationH = 0f;
        RotationV = 0f;

        // From sidebar to Model
        transform.parent.parent.GetChild(1).localRotation = Quaternion.Euler(
            new Vector3(0, 180, 0)
        );
    }

    public void SideBarOpen()
    {
        SideBarRect.DOAnchorPosX(-50, 0.5F).SetEase(Ease.OutBack);
    }

    public void SideBarClose()
    {
        SideBarRect.anchoredPosition = new Vector2(0f, 50);
    }
}
