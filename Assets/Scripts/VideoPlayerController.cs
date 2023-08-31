using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour, IPointerClickHandler
{
    private VideoPlayer videoPlayer;
    private bool isPlaying = false;
    private Camera mainCamera;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;

        mainCamera = Camera.main;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (isPlaying)
                {
                    PauseVideo();
                }
                else
                {
                    PlayVideo();
                }
            }
        }
    }

    private void PlayVideo()
    {
        videoPlayer.Play();
        isPlaying = true;
    }

    private void PauseVideo()
    {
        videoPlayer.Pause();
        isPlaying = false;
    }
}
