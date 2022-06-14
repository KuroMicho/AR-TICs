using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselController : MonoBehaviour
{
    [SerializeField] Sprite Ellipse_Empty;
    [SerializeField] Sprite Ellipse_Fill;

    public GameObject[] Topics;
    int Index = 0;

    void Start()
    {
        Topics[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Index == 0)
        {
            GameObject.Find("Ellipse-1").GetComponent<Image>().sprite = Ellipse_Fill;
            GameObject.Find("Ellipse-2").GetComponent<Image>().sprite = Ellipse_Empty;
            GameObject.Find("Ellipse-3").GetComponent<Image>().sprite = Ellipse_Empty;
        }

        if (Index == 1)
        {
            GameObject.Find("Ellipse-1").GetComponent<Image>().sprite = Ellipse_Empty;
            GameObject.Find("Ellipse-2").GetComponent<Image>().sprite = Ellipse_Fill;
            GameObject.Find("Ellipse-3").GetComponent<Image>().sprite = Ellipse_Empty;
        }

        if (Index == 2)
        {
            GameObject.Find("Ellipse-1").GetComponent<Image>().sprite = Ellipse_Empty;
            GameObject.Find("Ellipse-2").GetComponent<Image>().sprite = Ellipse_Empty;
            GameObject.Find("Ellipse-3").GetComponent<Image>().sprite = Ellipse_Fill;
        }
    }

    public void Next()
    {
        Index += 1;

        if (Index > 2)
        {
            Index = 0;
        }

        for (int i =0; i < Topics.Length; i++)
        {
            Topics[i].gameObject.SetActive(false);
            Topics[Index].gameObject.SetActive(true);
        }
    }

    public void Previous()
    {
        Index -= 1;

        if (Index < 0)
        {
            Index = 2;
        }

        for (int i =0; i < Topics.Length; i++)
        {
            Topics[i].gameObject.SetActive(false);
            Topics[Index].gameObject.SetActive(true);
        }
    }

}
