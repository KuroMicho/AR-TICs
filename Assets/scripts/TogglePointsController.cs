using UnityEngine;
using UnityEngine.UI;

public class TogglePointsController : MonoBehaviour
{
    [SerializeField]
    private Animator MenuAnimator;

    [SerializeField]
    private GameObject VideoPlayer;

    [SerializeField]
    private GameObject HelpPanel;

    [SerializeField]
    private Sprite LedGreen;

    [SerializeField]
    private Sprite LedRed;

    private GameObject[] Points;

    private bool isDisabled = false;

    private GameObject ChildPointBtn;

    private void Awake()
    {
        Points = GameObject.FindGameObjectsWithTag("Points");

        ChildPointBtn = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        bool isShowed = MenuAnimator.GetBool("Show");

        if (MenuAnimator != null && isShowed && !VideoPlayer.activeInHierarchy)
        {
            ChildPointBtn.SetActive(false);
        }
        else if (VideoPlayer != null && VideoPlayer.activeInHierarchy)
        {
            ChildPointBtn.SetActive(false);
        }
        else if (HelpPanel != null && HelpPanel.activeInHierarchy)
        {
            ChildPointBtn.SetActive(false);
        }
        else
        {
            ChildPointBtn.SetActive(true);
        }
    }

    public void TogglePoints()
    {
        if (!isDisabled)
        {
            foreach (GameObject Point in Points)
            {
                Point.SetActive(false);
                ChildPointBtn.GetComponent<Image>().sprite = LedRed;
                isDisabled = true;
            }
        }
        else
        {
            foreach (GameObject Point in Points)
            {
                Point.SetActive(true);
                ChildPointBtn.GetComponent<Image>().sprite = LedGreen;
                isDisabled = false;
            }
        }
    }
}
