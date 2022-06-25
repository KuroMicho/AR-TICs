using UnityEngine;
using DG.Tweening;

public class TextAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    private void Start()
    {
        TextRect = GetComponent<RectTransform>();
        TextRect
            .DOAnchorPosY(GetComponent<RectTransform>().anchoredPosition.y + 5, 0.8f)
            .SetEase(Ease.InOutBack)
            .SetLoops(3);
    }
}
