using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

public class MessageGenBehaviour : MonoBehaviour
{
    private RectTransform MessageRect;
    private TMP_Text MessageText;

    private int Number;

    private string[] Messages =
    {
        "Interactúa con Realidad Aumentada!",
        "Explora nueva tecnología!",
        "Aprende sobre Tecnología e Informática!"
    };

    private void Awake()
    {
        MessageRect = GetComponent<RectTransform>();
        MessageText = GetComponent<TMP_Text>();

        Number = Mathf.RoundToInt(Random.Range(0, 3));
        MessageText.text = Messages[Number];

        StartCoroutine(Transition());
        StopCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        MessageText.DOFade(0, 0.5f);

        yield return new WaitForSeconds(0.5f);
        MessageText.DOFade(1, 2);
        MessageRect.DOAnchorPosY(-180, 1).SetEase(Ease.OutElastic);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
