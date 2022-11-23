using UnityEngine;
using DG.Tweening;

public class ARTargetAnimBehaviour : MonoBehaviour
{
    private Vector3 OriginalScale;
    private Vector3 ScaleTo;

    private void Start()
    {
        OriginalScale = transform.localScale;
        ScaleTo = OriginalScale * 1.1f;

        transform.DOScale(ScaleTo, 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
