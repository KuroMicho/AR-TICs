using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransitionController : MonoBehaviour
{
    public void BtnPressed()
    {
        GetComponent<Animator>().SetTrigger("Pressed");
    }
}
