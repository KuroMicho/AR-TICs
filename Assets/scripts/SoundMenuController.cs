using UnityEngine;

public class SoundMenuController : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] Sounds;

    [SerializeField]
    private AudioSource AudioBGM;

    [SerializeField]
    private Animator MenuAnimator;

    private bool IsOpen = false;

    public void Play(string name)
    {
        IsOpen = MenuAnimator.GetBool("Show");

        foreach (AudioSource CurrentSound in Sounds)
        {
            if (CurrentSound != null && CurrentSound.isPlaying && IsOpen)
            {
                CurrentSound.Stop();
            }

            if (CurrentSound != null && CurrentSound.name == name && IsOpen)
            {
                CurrentSound.volume = 1;
                CurrentSound.PlayDelayed(1);
                AudioBGM.Pause();
            }

            if (name == "Stop" && !IsOpen)
            {
                CurrentSound.Stop();
                AudioBGM.UnPause();
            }
        }
    }
}
