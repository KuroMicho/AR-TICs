using UnityEngine;
using DG.Tweening;
using Vuforia;

public class BarAnimBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform BarRect;

    [SerializeField]
    private GameObject VideoPlayer;

    private bool TargetFound = false;

    private void Update()
    {
        if (VideoPlayer.activeInHierarchy)
        {
            BarClose();
        }

        if (!VideoPlayer.activeInHierarchy && TargetFound)
        {
            BarOpen();
        }
    }

    public void IsTrackingMarker(ImageTargetBehaviour ImageTarget)
    {
        if (ImageTarget != null)
        {
            TargetFound = ImageTarget.TargetStatus.Status == Status.TRACKED;
        }
    }

    public void BarOpen()
    {
        BarRect.DOAnchorPosY(30, 0.6f).SetEase(Ease.OutBack);
    }

    public void BarClose()
    {
        BarRect.DOAnchorPosY(-60, 0.6f).SetEase(Ease.OutBack);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
