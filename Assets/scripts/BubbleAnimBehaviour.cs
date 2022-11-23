using UnityEngine;
using DG.Tweening;
using TMPro;

public class BubbleAnimBehaviour : MonoBehaviour
{
    private RectTransform BubbleRect;
    private TMP_Text BubbleText;

    private void Start()
    {
        BubbleRect = GetComponent<RectTransform>();
        BubbleText = GetComponent<TMP_Text>();
    }

    public void Up()
    {
        BubbleText.DOFade(255, 0.5f);
        BubbleRect.DOAnchorPosY(20, 0.5f).SetEase(Ease.InBack);
        Down();
    }

    public void Down()
    {
        BubbleText.DOFade(0, 0.5f).SetDelay(0.5f);
        BubbleRect.DOAnchorPosY(0, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
