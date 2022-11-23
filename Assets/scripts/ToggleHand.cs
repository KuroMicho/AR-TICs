using UnityEngine;

public class ToggleHand : MonoBehaviour
{
    private bool IsOn = false;

    [SerializeField]
    private AudioSource TouchSound;

    [SerializeField]
    private GameObject Popup;

    public void SetPanelActive()
    {
        if (IsOn)
        {
            // ScrollArea Hide
            gameObject.SetActive(false);

            TouchSound.Play();
            IsOn = false;
        }
        else
        {
            // ScrollArea Show
            gameObject.SetActive(true);

            Popup.SetActive(false);
            TouchSound.Play();
            IsOn = true;
        }
    }
}
