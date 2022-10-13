using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

namespace YoutubePlayer
{
    public class VideoController : MonoBehaviour
    {
        [SerializeField]
        private YoutubePlayer YTPlayer;

        private VideoPlayer vPlayer;

        [SerializeField]
        private AudioSource GlobalMusic;

        [SerializeField]
        private GameObject Spinner;

        [SerializeField]
        private GameObject Alert;

        [SerializeField]
        private Button BtnStop;

        [SerializeField]
        private Sprite[] Img;

        [SerializeField]
        private GameObject BtnPlayAndPause;

        [SerializeField]
        private Button BtnReset;

        private bool isPlaying = false;

        public void PlayAndPauseVideo()
        {
            if (!isPlaying)
            {
                GlobalMusic.Stop();
                vPlayer.Play();
                BtnPlayAndPause.GetComponent<Image>().sprite = Img[1];
                isPlaying = true;
            }
            else
            {
                GlobalMusic.Stop();
                vPlayer.Pause();
                BtnPlayAndPause.GetComponent<Image>().sprite = Img[0];
                isPlaying = false;
            }
        }

        private void DisableButtons()
        {
            BtnPlayAndPause.GetComponent<Button>().interactable = false;
            BtnPlayAndPause.GetComponent<Image>().sprite = Img[0];
            BtnReset.interactable = false;
        }

        private void Awake()
        {
            DisableButtons();
            Spinner.SetActive(false);
            vPlayer = YTPlayer.GetComponent<VideoPlayer>();
            vPlayer.prepareCompleted += VideoPlayerPreparedCompleted;
        }

        private void Update()
        {
            if (BtnPlayAndPause.GetComponent<Button>().interactable)
            {
                Spinner.SetActive(false);
            }
        }

        private void VideoPlayerPreparedCompleted(VideoPlayer source)
        {
            BtnPlayAndPause.GetComponent<Button>().interactable = source.isPrepared;
            BtnReset.interactable = source.isPrepared;
        }

        public void StopVideo()
        {
            vPlayer.Stop();
            isPlaying = false;
            DisableButtons();
            transform.parent.GetChild(1).gameObject.SetActive(false);
            GlobalMusic.PlayDelayed(0.2f);
        }

        private void CloseAlert()
        {
            Alert.SetActive(false);
            StopVideo();
        }

        public async void PrepareVideo()
        {
            Spinner.SetActive(true);
            try
            {
                await YTPlayer.PrepareVideoAsync(URLController.YoutubeURL);
            }
            catch
            {
                Alert.SetActive(true);
                Invoke("CloseAlert", 5f);
            }
        }

        public void ResetVideo()
        {
            vPlayer.Stop();
            isPlaying = false;
            PlayAndPauseVideo();
        }
    }
}
