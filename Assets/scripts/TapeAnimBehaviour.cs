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
        TapeRect.DOAnchorPosX(30, 0.8f).SetEase(Ease.InOutQuint);
        SlideSound.Play();
    }

    public void CloseTape()
    {
        TapeRect.DOAnchorPosX(-570, 0.8f).SetEase(Ease.InOutQuint);
        SlideSound.Play();
    }
}
