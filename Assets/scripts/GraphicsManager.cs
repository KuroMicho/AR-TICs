using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class GraphicsManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown Dropdown;

    public RenderPipelineAsset[] QualityLevels;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Quality"))
        {
            PlayerPrefs.SetInt("Quality", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = QualityLevels[value];
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetInt("Quality", Dropdown.value);
    }

    void Load()
    {
        Dropdown.value = PlayerPrefs.GetInt("Quality");
    }
}
