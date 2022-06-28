using UnityEngine;
using DG.Tweening;

public class TextAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    private void Start()
    {
        TextRect = GetComponent<RectTransform>();
        TextRect
            .DOAnchorPosY(GetComponent<RectTransform>().anchoredPosition.y + 5, 1)
            .SetEase(Ease.InOutBounce)
            .SetLoops(3);
    }
}
