using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AchievementAnimBehaviour : MonoBehaviour
{
    private RectTransform TextRect;

    public void MoveText()
    {
        TextRect = GetComponent<RectTransform>();
        TextRect.DOAnchorPosX(-200f, 1F).SetEase(Ease.OutBack);
    }
}
