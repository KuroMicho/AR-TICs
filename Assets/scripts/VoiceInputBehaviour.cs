using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class VoiceInputBehaviour : MonoBehaviour
{
    public UnityEvent BtnDown;
    public UnityEvent BtnUp;

    private void OnMouseUp()
    {
        BtnUp?.Invoke();
    }

    private void OnMouseDown()
    {
        BtnDown?.Invoke();
    }
}
