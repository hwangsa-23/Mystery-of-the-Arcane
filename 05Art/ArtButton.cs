using UnityEngine;
using UnityEngine.UI;

public class ArtButtonBinder : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    void Start()
    {
        // ArtSceneController 인스턴스가 존재하는지 확인
        if (ArtSceneController.Instance == null)
        {
            return;
        }

        // Start 버튼 연결
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() => ArtSceneController.Instance.GenerateRandomScenes());
        }

        // Quit 버튼 연결
        if (quitButton != null)
        {
            quitButton.onClick.RemoveAllListeners();
            quitButton.onClick.AddListener(() => ArtSceneController.Instance.QuitScene());
        }
    }
}
