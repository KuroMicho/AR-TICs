using UnityEngine;

public class ToggleGroundInfo : MonoBehaviour
{
    private bool IsOn = false;

    [SerializeField]
    private AudioSource TouchSound;

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
            TouchSound.Play();
            IsOn = true;
        }
    }
}
