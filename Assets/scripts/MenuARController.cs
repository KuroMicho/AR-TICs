using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MenuARController : MonoBehaviour
{
    private Animator MenuAnimator;

    [SerializeField]
    private GameObject Container;

    [SerializeField]
    private GameObject VideoPlayer;

    [SerializeField]
    private TMP_Text TextScroll;

    private Button ShowHideBtn;

    private bool IsOpen = false;

    private void Start()
    {
        MenuAnimator = GetComponent<Animator>();
        ShowHideBtn = transform.GetChild(0).GetComponent<Button>();
    }

    private void Update()
    {
        if (ShowHideBtn != null)
        {
            ShowHideBtn.interactable = true;

            if (VideoPlayer.gameObject.activeInHierarchy)
            {
                ShowHideBtn.interactable = false;
            }
        }
    }

    public void ShowHideMenu()
    {
        IsOpen = MenuAnimator.GetBool("Show");
        MenuAnimator.SetBool("Show", !IsOpen);

        if (!IsOpen)
        {
            Container.SetActive(false);
            StartCoroutine(ShowTextScroll());
            StopCoroutine(ShowTextScroll());
        }
        else
        {
            Container.SetActive(true);
        }
    }

    IEnumerator ShowTextScroll()
    {
        TextScroll.DOFade(1, 2);

        yield return new WaitForSeconds(5);

        TextScroll.DOFade(0, 1);
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
