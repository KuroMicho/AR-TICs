using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnAnimBehaviour : MonoBehaviour
{
    private RectTransform BtnRect;

    public void BtnPressed()
    {
        BtnRect = GetComponent<RectTransform>();
        BtnRect.DOAnchorPosY(BtnRect.anchoredPosition.y + 2, 0.5f).SetEase(Ease.InOutBack);
    }
}
