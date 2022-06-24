using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVolume : MonoBehaviour
{
    [SerializeField]
    private Sprite Sound;

    [SerializeField]
    private Sprite NoSound;

    [SerializeField]
    private Slider Slider;

    private bool IsActive = true;

    void Mute()
    {
        Slider.value = 0;
    }

    void Full()
    {
        Slider.value = 1;
    }

    public void ChangeImage()
    {
        if (IsActive)
        {
            GetComponent<Image>().sprite = NoSound;
            IsActive = false;
            Mute();
        }
        else
        {
            GetComponent<Image>().sprite = Sound;
            IsActive = true;
            Full();
        }
    }
}
