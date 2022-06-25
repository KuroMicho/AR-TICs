using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    private bool IsOn = false;

    [SerializeField]
    private AudioSource TouchSound;

    [SerializeField]
    private GameObject SideBar;

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
            TouchSound.Play();
            IsOn = true;
        }
    }
}
