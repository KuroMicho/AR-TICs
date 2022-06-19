using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    // For Buttons
    public void BtnPressed()
    {
        GetComponent<Animator>().SetTrigger("Pressed");
    }

    // Bar in AR Scene
    public void BarAnim()
    {
        GetComponent<Animator>().Play("Bar", -1, 0f);
    }

    // Destroy LayerParticles
    public void OnClose()
    {
        Destroy(gameObject);
    }
}
