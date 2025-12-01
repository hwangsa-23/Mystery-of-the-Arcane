using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoEndToBackground : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // VideoPlayer 넣기
    public RawImage rawImage;         // 비디오 출력 RawImage
    public GameObject buttonsParent;  // 버튼 묶음 (Home, Quit)

    void Start()
    {
        buttonsParent.SetActive(false);   // 영상 시작할 때 버튼 숨김
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 🔥 영상 끝나면 RawImage 투명하게 만들기
        rawImage.color = new Color(1, 1, 1, 0);

        // 🔥 버튼 보이기
        buttonsParent.SetActive(true);
    }
}
