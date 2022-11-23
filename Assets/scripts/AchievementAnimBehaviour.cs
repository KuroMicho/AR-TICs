using UnityEngine;
using DG.Tweening;

public class AchievementAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    public void MoveText()
    {
        TextRect = GetComponent<RectTransform>();
        TextRect.DOAnchorPosX(-160, 1).SetEase(Ease.OutBack);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
