using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class GraphicsManager : MonoBehaviour
{
    public RenderPipelineAsset[] QualityLevels;
    void Start()
    {
        GetComponent<TMP_Dropdown>().value = QualitySettings.GetQualityLevel();       
    }

    public void ChangeLevel(int value)
    {
        QualitySettings.SetQualityLevel(value);
        QualitySettings.renderPipeline = QualityLevels[value];
    }
}
