using UnityEngine;
using DG.Tweening;

public class BtnAnimBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform BtnRect;

    private float AxisX;
    private float AxisY;

    private void Start()
    {
        AxisX = BtnRect.anchoredPosition.x;
        AxisY = BtnRect.anchoredPosition.y;
    }

    public void BtnPressed()
    {
        BtnRect.anchoredPosition = new Vector2(AxisX, AxisY);
        BtnRect.DOAnchorPosY(BtnRect.anchoredPosition.y + 3, 0.6f).SetEase(Ease.OutElastic);
    }
}
