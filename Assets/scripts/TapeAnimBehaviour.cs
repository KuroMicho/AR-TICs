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
        TapeRect.DOAnchorPosX(28, 0.8f).SetEase(Ease.OutQuad);
        SlideSound.Play();
    }

    public void CloseTape()
    {
        TapeRect.DOAnchorPosX(-420, 0.8f).SetEase(Ease.InQuad);
        SlideSound.Play();
    }
}
