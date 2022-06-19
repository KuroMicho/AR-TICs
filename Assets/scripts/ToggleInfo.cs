using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    bool IsOn = false;

    public void SetActive()
    {
        if (IsOn)
        {
            gameObject.SetActive(false);
            transform.parent.parent.GetChild(0).gameObject.SetActive(true);
            IsOn = false;
        }
        else
        {
            gameObject.SetActive(true);
            transform.parent.parent.GetChild(0).gameObject.SetActive(false);
            IsOn = true;
        }
    }
}
