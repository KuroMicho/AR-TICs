using UnityEngine;
using DG.Tweening;

public class TapeAnimBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform TapeRect;

    [SerializeField]
    private AudioSource SlideSound;

    public void OpenTape()
    {
        TapeRect.DOAnchorPosX(20, 0.8f).SetEase(Ease.InOutQuint);
        SlideSound.Play();
    }

    public void CloseTape()
    {
        TapeRect.DOAnchorPosX(-520, 0.8f).SetEase(Ease.InOutQuint);
        SlideSound.Play();
    }
}
