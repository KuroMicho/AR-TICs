using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModelPointController : MonoBehaviour
{
    private string BtnName;
    public GameObject Popup;
    public TMP_Text Desc;

    /*
    if (Input.GetMouseButtonDown(0))
        {
             Ray RayTouch = Camera.main.ScreenPointToRay(Input.mousePosition); */

    /*
    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
             Ray RayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); */

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray RayTouch = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Physics.Raycast(RayTouch, out Hit))
            {
                BtnName = Hit.transform.name;

                switch (BtnName)
                {
                    case "test1":
                        Debug.Log("Input Test2");
                        break;
                    case "test2":
                        Popup.SetActive(true);
                        Desc.text = "Prueba";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
