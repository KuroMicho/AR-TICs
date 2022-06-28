using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarouselController : MonoBehaviour
{
    [SerializeField]
    private Sprite Ellipse_Empty;

    [SerializeField]
    private Sprite Ellipse_Fill;

    [SerializeField]
    private GameObject[] Modules;

    [SerializeField]
    private GameObject Ellipse1;

    [SerializeField]
    private GameObject Ellipse2;

    [SerializeField]
    private GameObject Ellipse3;

    [SerializeField]
    private TMP_Text[] ModulesText;

    int Index = 0;

    void Start()
    {
        Modules[0].SetActive(true);
        ModulesText[0].enabled = true;
    }

    private void Update()
    {
        if (Index == 0)
        {
            Ellipse1.GetComponent<Image>().sprite = Ellipse_Fill;
            Ellipse2.GetComponent<Image>().sprite = Ellipse_Empty;
            Ellipse3.GetComponent<Image>().sprite = Ellipse_Empty;
        }

        if (Index == 1)
        {
            Ellipse1.GetComponent<Image>().sprite = Ellipse_Empty;
            Ellipse2.GetComponent<Image>().sprite = Ellipse_Fill;
            Ellipse3.GetComponent<Image>().sprite = Ellipse_Empty;
        }

        if (Index == 2)
        {
            Ellipse1.GetComponent<Image>().sprite = Ellipse_Empty;
            Ellipse2.GetComponent<Image>().sprite = Ellipse_Empty;
            Ellipse3.GetComponent<Image>().sprite = Ellipse_Fill;
        }
    }

    public void Next()
    {
        Index += 1;

        if (Index > 2)
        {
            Index = 0;
        }

        for (int i = 0; i < Modules.Length; i++)
        {
            Modules[i].SetActive(false);
            Modules[Index].SetActive(true);

            ModulesText[i].enabled = false;
            ModulesText[Index].enabled = true;
        }
    }

    public void Previous()
    {
        Index -= 1;

        if (Index < 0)
        {
            Index = 2;
        }

        for (int i = 0; i < Modules.Length; i++)
        {
            Modules[i].SetActive(false);
            Modules[Index].SetActive(true);

            ModulesText[i].enabled = false;
            ModulesText[Index].enabled = true;
        }
    }
}
