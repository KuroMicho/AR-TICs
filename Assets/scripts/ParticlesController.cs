using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] RectTransform ParticlesBox;
    [SerializeField] Image CircleImg;

    [Range(1, 0)] float Progress = 1f;

    private void FixedUpdate()
    {
        if (QuizManager.CounterIsRunning)
        {
            Progress -= 0.04f * 1 * Time.deltaTime;
            CircleImg.fillAmount = Progress;
            ParticlesBox.rotation = Quaternion.Euler(new Vector3(0f, 0f, -Progress * 360));
        }

        if (!QuizManager.CounterIsRunning && !QuizManager.IsFinished)
        {
            Progress = 1f;
        }
    }
}
