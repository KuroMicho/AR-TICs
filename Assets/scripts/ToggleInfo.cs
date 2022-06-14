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
            IsOn = false;
        } else
        {
            gameObject.SetActive(true);
            IsOn = true;
        }
    }
}
