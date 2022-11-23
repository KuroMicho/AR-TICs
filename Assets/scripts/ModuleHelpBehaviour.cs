using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class ModuleHelpBehaviour : MonoBehaviour
{
    private RectTransform HelpRect;
    private Image HelpImage;

    [SerializeField]
    private GameObject HelpBtn;

    private void Awake()
    {
        HelpBtn.GetComponent<Button>().interactable = false;
        HelpImage = GetComponentInChildren<Image>();
        HelpRect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        if (HelpImage.gameObject.activeInHierarchy && HelpRect.gameObject.activeInHierarchy)
        {
            if (!SceneController.HelpShowed)
            {
                FadeIn();
            }
            else
            {
                PlayTransition();
            }
        }
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }

    public void FadeIn()
    {
        HelpImage.DOFade(0.7f, 1);
        HelpRect.DOAnchorPos(new Vector2(20, 20), 1.5f, false).SetEase(Ease.InOutQuint);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2);
        HelpImage.DOFade(0, 0.5f);
        HelpRect.DOAnchorPos(new Vector2(115, 60), 0, false).SetDelay(0.5f);
        SceneController.HelpShowed = true;
    }

    public void PlayTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        HelpBtn.GetComponent<Image>().DOFade(0, 1);
        HelpBtn.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1.5f);

        HelpBtn.GetComponent<Button>().interactable = true;
        HelpBtn.GetComponent<Image>().DOFade(1, 1);
    }
}
