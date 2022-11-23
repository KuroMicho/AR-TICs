using UnityEngine;
using TMPro;
using DG.Tweening;

public class ModelPointController : MonoBehaviour
{
    [SerializeField]
    private GameObject Popup;

    [SerializeField]
    private TMP_Text Desc;

    private RectTransform PopupRect;
    private string Point;

    private void Start()
    {
        PopupRect = Popup.GetComponent<RectTransform>();
    }

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
                    // Computacion
                    case "CPU1":
                        Desc.text = "Procesador AMD Ryzen Threadripper 3990X";
                        PopupShow();
                        break;
                    case "CPU2":
                        Desc.text = "Pines o contactos";
                        PopupShow();
                        break;
                    case "CPU3":
                        Desc.text = "IHS (Placa de cobre que protege el núcleo)";
                        PopupShow();
                        break;

                    case "HDD1":
                        Desc.text = "HDD SEAGATE BarraCuda 1TB";
                        PopupShow();
                        break;

                    case "SSD1":
                        Desc.text = "SSD Samsung 860 EVO 1TB";
                        PopupShow();
                        break;
                    case "SSD2":
                        Desc.text = "Conector SATA";
                        PopupShow();
                        break;
                    case "SSD3":
                        Desc.text = "Conector de alimentación";
                        PopupShow();
                        break;

                    case "M21":
                        Desc.text = "Samsug M.2 970 EVO NVMe 500GB Dimensión 2280";
                        PopupShow();
                        break;
                    case "M22":
                        Desc.text =
                            "M Key: con 5 contactos y otra de entre 59 y 66 contactos. Se usa en interfaz PCIe x4";
                        PopupShow();
                        break;

                    case "MB1":
                        Desc.text = "Chipset AMD TRX40 AORUS";
                        PopupShow();
                        break;
                    case "MB2":
                        Desc.text = "Quad Channel DDR4 RAM";
                        PopupShow();
                        break;
                    case "MB3":
                        Desc.text = "PCIe 4.0 x16/x8/x16/x8";
                        PopupShow();
                        break;
                    case "MB4":
                        Desc.text = "M.2 NVMe PCIe 4.0";
                        PopupShow();
                        break;
                    case "MB5":
                        Desc.text = "Disipador de calor (Aletas)";
                        PopupShow();
                        break;
                    case "MB6":
                        Desc.text = "Entrada ATX de alimentación";
                        PopupShow();
                        break;
                    case "MB7":
                        Desc.text = "Panel de conectividad (USB 3.1 Gigabit Ethernet, Sonic Audio)";
                        PopupShow();
                        break;

                    case "PS1":
                        Desc.text = "Fuente Modular Corsair SF600 600W 80 PLUS Platinum";
                        PopupShow();
                        break;
                    case "PS2":
                        Desc.text = "Ventilador";
                        PopupShow();
                        break;
                    case "PS3":
                        Desc.text = "Conector de entrada";
                        PopupShow();
                        break;
                    case "PS4":
                        Desc.text = "Interruptor de Encendido/Apagado";
                        PopupShow();
                        break;

                    case "GC1":
                        Desc.text = "GeForce RTX 3070 8GB GDDR6";
                        PopupShow();
                        break;
                    case "GC2":
                        Desc.text = "DisplayPort 1.4";
                        PopupShow();
                        break;
                    case "GC3":
                        Desc.text = "Conector HDMI 2.1";
                        PopupShow();
                        break;
                    case "GC4":
                        Desc.text = "PCI Express 4.0";
                        PopupShow();
                        break;
                    case "GC5":
                        Desc.text = "Conector de Corriente 1x12 pines PEG";
                        PopupShow();
                        break;

                    case "LP1":
                        Desc.text = "Apple MacBook Pro 13";
                        PopupShow();
                        break;
                    case "LP2":
                        Desc.text = "Trackpad Force Touch";
                        PopupShow();
                        break;
                    case "LP3":
                        Desc.text = "Touch Bar y Touch ID";
                        PopupShow();
                        break;
                    case "LP4":
                        Desc.text = "Puerto de carga";
                        PopupShow();
                        break;
                    case "LP5":
                        Desc.text = "Puertos Thunderbolt 3 (USB-C)";
                        PopupShow();
                        break;
                    case "LP6":
                        Desc.text = "Magic Keyboard retroiluminado";
                        PopupShow();
                        break;
                    case "LP7":
                        Desc.text =
                            "Brillante pantalla Retina de 13.3 pulgadas con Tecnología True Tone (1)";
                        PopupShow();
                        break;

                    // Movil

                    case "IP1":
                        Desc.text = "Apple Iphone 14 Pro Max";
                        PopupShow();
                        break;

                    case "IP2":
                        Desc.text = "Chip A16 Bionic";
                        PopupShow();
                        break;

                    case "IP3":
                        Desc.text =
                            "Pantalla de 6.7 pulgadas, Retina XDR OLED, 1290 x 2796 pixeles, 24 bit";
                        PopupShow();
                        break;

                    case "IP4":
                        Desc.text =
                            "Triple cámara, 48MP principal, 12MP ultra gran angular, 12MP teleobjetivo, TOF 3D LiDAR scanner, 60 fps";
                        PopupShow();
                        break;

                    case "IP5":
                        Desc.text = "Cámara Selfie 12 MP, HDR, 4K, 60 fps";
                        PopupShow();
                        break;

                    // TIC 4.0

                    case "DR1":
                        Desc.text = "Mini Drone S9 Broadream";
                        PopupShow();
                        break;
                    case "DR2":
                        Desc.text = "Hélice";
                        PopupShow();
                        break;
                    case "DR3":
                        Desc.text = "Cámara";
                        PopupShow();
                        break;
                    case "DR4":
                        Desc.text = "Luz LED de alto brillo";
                        PopupShow();
                        break;
                    case "DR5":
                        Desc.text = "Puerto de carga";
                        PopupShow();
                        break;
                    case "DR6":
                        Desc.text = "Puerto USB";
                        PopupShow();
                        break;

                    case "ROB1":
                        Desc.text = "Pinzas";
                        PopupShow();
                        break;
                    case "ROB2":
                        Desc.text = "Muñeca";
                        PopupShow();
                        break;
                    case "ROB3":
                        Desc.text = "Base o columna";
                        PopupShow();
                        break;
                    case "ROB4":
                        Desc.text = "Unidad de soporte";
                        PopupShow();
                        break;
                    case "ROB5":
                        Desc.text = "Codo";
                        PopupShow();
                        break;
                    case "ROB6":
                        Desc.text = "Antebrazo";
                        PopupShow();
                        break;
                    case "ROB7":
                        Desc.text = "Parte superior del brazo";
                        PopupShow();
                        break;
                    case "ROB8":
                        Desc.text = "Espalda";
                        PopupShow();
                        break;
                    case "ROB9":
                        Desc.text = "Manija";
                        PopupShow();
                        break;

                    case "VR1":
                        Desc.text = "Oculus Rift CV1";
                        PopupShow();
                        break;
                    case "VR2":
                        Desc.text = "Sistema de velcros";
                        PopupShow();
                        break;
                    case "VR3":
                        Desc.text = "360 grados IR LED seguimiento de cabeza";
                        PopupShow();
                        break;
                    case "VR4":
                        Desc.text = "Lentes Fresnel hibridas";
                        PopupShow();
                        break;
                    case "VR5":
                        Desc.text = "Pentile AMOLED con una resolución de 2160 x 1200 pixeles";
                        PopupShow();
                        break;
                    case "VR6":
                        Desc.text = "Ajustador de IPD (distancia interpupilar)";
                        PopupShow();
                        break;
                    case "VR7":
                        Desc.text = "Solución de audio integrado 3D";
                        PopupShow();
                        break;

                    case "CA1":
                        Desc.text = "Tesla Model 3 2018: Automóvil eléctrico sedan de cinco plazas";
                        PopupShow();
                        break;
                    case "CA2":
                        Desc.text =
                            "Radio Detección y Alcance (RADAR): Ondas de radio que rebotan en superficies distantes";
                        PopupShow();
                        break;
                    case "CA3":
                        Desc.text =
                            "Cámaras: Usadas para ver en alta resolución, y leer señales o marcas viales";
                        PopupShow();
                        break;

                    case "AS1":
                        Desc.text = "Amazon Echo Dot 3";
                        PopupShow();
                        break;
                    case "AS2":
                        Desc.text = "Plástico de policarbonato (PC)";
                        PopupShow();
                        break;
                    case "AS3":
                        Desc.text = "Almohadilla antideslizante";
                        PopupShow();
                        break;
                    case "AS4":
                        Desc.text = "Botón de acción";
                        PopupShow();
                        break;
                    case "AS5":
                        Desc.text = "Botón de micrófono";
                        PopupShow();
                        break;
                    case "AS6":
                        Desc.text = "Botón de subir volumen";
                        PopupShow();
                        break;
                    case "AS7":
                        Desc.text = "Botón de bajar volumen";
                        PopupShow();
                        break;

                    case "EOL1":
                        Desc.text = "Góndola";
                        PopupShow();
                        break;
                    case "EOL2":
                        Desc.text = "Generador";
                        PopupShow();
                        break;
                    case "EOL3":
                        Desc.text = "Aspa";
                        PopupShow();
                        break;
                    case "EOL4":
                        Desc.text = "Torre";
                        PopupShow();
                        break;

                    case "SP1":
                        Desc.text = "12 paneles solares monocristalino";
                        PopupShow();
                        break;
                    case "SP2":
                        Desc.text = "Tubo galvanizado 48.3mm";
                        PopupShow();
                        break;
                    case "SP3":
                        Desc.text = "330 W PV (fotovoltaica) total aproximadamente 3960 W";
                        PopupShow();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void PopupShow()
    {
        Popup.SetActive(true);
        Resize();
        Popup.transform.localScale = new Vector2(0f, 0f);
        Popup.transform.DOScale(new Vector2(1f, 1f), 0.8f).SetEase(Ease.OutBack);
    }

    public void PopupClose()
    {
        Popup.transform.DOScale(new Vector2(0f, 0f), 0.2f).SetEase(Ease.InBack);
    }

    private void Resize()
    {
        if (Desc.text.Length <= 20)
        {
            PopupRect.sizeDelta = new Vector2(100, 60);
            return;
        }

        if (Desc.text.Length > 20 && Desc.text.Length <= 40)
        {
            PopupRect.sizeDelta = new Vector2(150, 90);
            return;
        }

        if (Desc.text.Length > 40)
        {
            PopupRect.sizeDelta = new Vector2(200, 120);
            return;
        }
    }
}
