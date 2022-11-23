using UnityEngine;

public class ToggleSideBar : MonoBehaviour
{
    private bool IsOn = false;

    [SerializeField]
    private AudioSource TouchSound;

    [SerializeField]
    private GameObject SideBar;

    [SerializeField]
    private GameObject Popup;

    public void SetPanelActive()
    {
        if (IsOn)
        {
            // ScrollArea Hide
            gameObject.SetActive(false);

            // SideBar Show
            SideBar.SetActive(true);
            TouchSound.Play();
            IsOn = false;
        }
        else
        {
            // ScrollArea Show
            gameObject.SetActive(true);

            // SideBar Hide
            SideBar.SetActive(false);
            Popup.SetActive(false);
            TouchSound.Play();
            IsOn = true;
        }
    }
}
