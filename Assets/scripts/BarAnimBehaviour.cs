using UnityEngine;
using DG.Tweening;

public class BarAnimBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform BarRect;

    public void BarOpen()
    {
        BarRect.DOAnchorPosY(30, 0.5F).SetEase(Ease.OutBack);
    }

    public void BarClose()
    {
        BarRect.anchoredPosition = new Vector2(0f, -30);
    }
}
