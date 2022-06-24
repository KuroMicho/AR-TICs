using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    private bool IsOn = false;

    [SerializeField]
    private AudioSource TouchSound;

    public void SetPanelActive()
    {
        if (IsOn)
        {
            gameObject.SetActive(false);
            transform.parent.parent.GetChild(0).gameObject.SetActive(true);
            TouchSound.Play();
            IsOn = false;
        }
        else
        {
            gameObject.SetActive(true);
            transform.parent.parent.GetChild(0).gameObject.SetActive(false);
            TouchSound.Play();
            IsOn = true;
        }
    }
}
