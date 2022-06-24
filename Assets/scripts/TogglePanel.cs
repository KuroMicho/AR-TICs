using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    [SerializeField]
    private Canvas Canv;

    private bool IsOn = false;

    public void SetActive()
    {
        if (IsOn)
        {
            Canv.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
            IsOn = false;
        }
        else
        {
            Canv.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.SetActive(true);
            IsOn = true;
        }
    }
}
