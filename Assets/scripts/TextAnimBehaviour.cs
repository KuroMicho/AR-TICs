using UnityEngine;
using DG.Tweening;

public class TextAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    private void Start()
    {
        TextRect = GetComponent<RectTransform>();

        TextRect
            .DOAnchorPosY(TextRect.anchoredPosition.y + 5, 0.7f)
            .SetEase(Ease.InOutBack)
            .SetLoops(4, LoopType.Yoyo);
    }
}
