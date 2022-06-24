using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideBarController : MonoBehaviour
{
    private RectTransform SideBarRect;

    private float RotationY = 0f;
    private float RotationX = 0f;
    private bool IsPressed = false;

    private bool AxisY = false;
    private bool AxisX = false;

    private void FixedUpdate()
    {
        if (IsPressed && AxisY)
        {
            RotationY += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).rotation = Quaternion.Euler(
                new Vector3(0f, RotationY * 45, 0f)
            );
        }

        if (IsPressed && AxisX)
        {
            RotationX += 1 * Time.deltaTime;
            transform.parent.parent.GetChild(1).rotation = Quaternion.Euler(
                new Vector3(RotationX * 45, 0f, 0f)
            );
        }
    }

    public void RotateY()
    {
        AxisY = true;
        AxisX = false;
        IsPressed = !IsPressed;
    }

    public void RotateX()
    {
        AxisY = false;
        AxisX = true;
        IsPressed = !IsPressed;
    }

    public void Reset()
    {
        IsPressed = false;
        RotationX = RotationY = 0f;
        transform.parent.parent.GetChild(1).rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void SideBarOpen()
    {
        SideBarRect = GetComponent<RectTransform>();
        SideBarRect.DOAnchorPosX(-50, 0.5F).SetEase(Ease.OutBack);
    }

    public void SideBarClose()
    {
        SideBarRect.anchoredPosition = new Vector2(0f, 50);
    }
}
