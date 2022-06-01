using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider VolumenSlider; 
    
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolumen"))
        {
            PlayerPrefs.SetFloat("musicVolumen", 1);
            Load();
        } else
        {
            Load();
        }
    }

    public void ChangeVolumen()
    {
        AudioListener.volume = VolumenSlider.value;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolumen", VolumenSlider.value);
    }

    void Load()
    {
        VolumenSlider.value = PlayerPrefs.GetFloat("musicVolumen");
    }
} 
