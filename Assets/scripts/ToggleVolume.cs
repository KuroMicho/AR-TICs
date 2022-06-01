using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleVolume : MonoBehaviour
{
    [SerializeField] Sprite sound;
    [SerializeField] Sprite no_sound;
    bool IsActive = true;

    void Mute()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = 0;
    }

    void Full()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = 1;
    }

    public void ChangeImage()
    {
        if (IsActive)
        {
            gameObject.GetComponent<Image>().sprite = no_sound;
            IsActive = false;
            Mute();
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = sound;
            IsActive = true;
            Full();
        }
    }
}
