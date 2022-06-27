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
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray RayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;

            if (Physics.Raycast(RayTouch, out Hit))
            {
                Point = Hit.transform.name;

                switch (Point)
                {
                    case "CPU1":
                        PopUpBehaviour();
                        Desc.text = "Procesador AMD Ryzen Threadripper 3990X";
                        break;
                    case "CPU2":
                        PopUpBehaviour();
                        Desc.text = "Pines o contactos";
                        break;
                    case "CPU3":
                        PopUpBehaviour();
                        Desc.text = "IHS (Placa de cobre que protege el nucleo)";
                        break;
                    case "HDD1":
                        PopUpBehaviour();
                        Desc.text = "HDD SEAGATE BarraCuda 1TB";
                        break;
                    case "SSD1":
                        PopUpBehaviour();
                        Desc.text = "SSD Samsung 860 EVO 1TB";
                        break;
                    case "SSD2":
                        PopUpBehaviour();
                        Desc.text = "Conector SATA";
                        break;
                    case "SSD3":
                        PopUpBehaviour();
                        Desc.text = "Conector de alimentacion";
                        break;
                    case "LP1":
                        PopUpBehaviour();
                        Desc.text = "Apple MacBook Pro 13";
                        break;
                    case "LP2":
                        PopUpBehaviour();
                        Desc.text = "Trackpad Force Touch";
                        break;
                    case "LP3":
                        PopUpBehaviour();
                        Desc.text = "Touch Bar y Touch ID";
                        break;
                    case "LP4":
                        PopUpBehaviour();
                        Desc.text = "Puerto de carga";
                        break;
                    case "LP5":
                        PopUpBehaviour();
                        Desc.text = "Puertos Thunderbolt 3 (USB-C)";
                        break;
                    case "LP6":
                        PopUpBehaviour();
                        Desc.text = "Magic Keyboard retroiluminado";
                        break;
                    case "LP7":
                        PopUpBehaviour();
                        Desc.text =
                            "Brillante pantalla Retina de 13.3 pulgadas con Tecnologia True Tone (1)";
                        break;
                    case "DR1":
                        PopUpBehaviour();
                        Desc.text = "Mini Drone S9 Broadream";
                        break;
                    case "DR2":
                        PopUpBehaviour();
                        Desc.text = "Helice";
                        break;
                    case "DR3":
                        PopUpBehaviour();
                        Desc.text = "Camara";
                        break;
                    case "DR4":
                        PopUpBehaviour();
                        Desc.text = "Luz LED de alto brillo";
                        break;
                    case "DR5":
                        PopUpBehaviour();
                        Desc.text = "Puerto de carga";
                        break;
                    case "DR6":
                        PopUpBehaviour();
                        Desc.text = "Puerto USB";
                        break;
                    case "ROB1":
                        PopUpBehaviour();
                        Desc.text = "Pinzas";
                        break;
                    case "ROB2":
                        PopUpBehaviour();
                        Desc.text = "Muneca";
                        break;
                    case "ROB3":
                        PopUpBehaviour();
                        Desc.text = "Base o columna";
                        break;
                    case "ROB4":
                        PopUpBehaviour();
                        Desc.text = "Unidad de soporte";
                        break;
                    case "ROB5":
                        PopUpBehaviour();
                        Desc.text = "Codo";
                        break;
                    case "ROB6":
                        PopUpBehaviour();
                        Desc.text = "Antebrazo";
                        break;
                    case "ROB7":
                        PopUpBehaviour();
                        Desc.text = "Parte superior del brazo";
                        break;
                    case "ROB8":
                        PopUpBehaviour();
                        Desc.text = "Espalda";
                        break;
                    case "ROB9":
                        PopUpBehaviour();
                        Desc.text = "Manija";
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
        Popup.transform.DOScale(new Vector2(1f, 1f), 1f).SetEase(Ease.OutBack);
    }
}
