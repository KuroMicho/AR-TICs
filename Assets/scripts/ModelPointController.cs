using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ModelPointController : MonoBehaviour
{
    private string Point;

    [SerializeField]
    private GameObject Popup;

    [SerializeField]
    private TMP_Text Desc;

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
                Point = Hit.transform.name;

                switch (Point)
                {
                    case "CPU1":
                        PopUpBehaviour();
                        Desc.text = "Serial Number";
                        break;
                    case "HDD1":
                        Debug.Log("Input HDD1");
                        break;
                    case "SSD1":
                        PopUpBehaviour();
                        Desc.text = "Conexion SATA";
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void PopUpBehaviour()
    {
        Popup.transform.localScale = new Vector2(0f, 0f);
        Popup.SetActive(true);
        Popup.transform.DOScale(new Vector2(1f, 1f), 0.6f).SetEase(Ease.OutBack);
    }
}
