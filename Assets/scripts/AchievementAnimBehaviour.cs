using UnityEngine;
using DG.Tweening;

public class AchievementAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    public void MoveText()
    {
        TextRect = GetComponent<RectTransform>();
        TextRect.DOAnchorPosX(-200, 1).SetEase(Ease.OutBack);
    }
}
