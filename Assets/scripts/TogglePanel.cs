using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    bool IsOn = false;

    public void SetActive()
    {
        if (IsOn)
        {
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            IsOn = false;
        } else
        {
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.SetActive(true);
            IsOn = true;
        }
    }
}
