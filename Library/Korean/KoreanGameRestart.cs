using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KoreanGameRestart : MonoBehaviour
{
    [Header("UI")]
    public Text GameName;          // 게임 이름 텍스트
    public Button RestartButton;     // 시작 버튼
    public Button QuitButton;      // 종료 버튼

    void Start()
    {
        // 버튼 이벤트 등록
        if (RestartButton != null)
            RestartButton.onClick.AddListener(OnRestartButtonClicked);
        else
            Debug.LogWarning("StartButton이 연결되지 않았습니다!");

        if (QuitButton != null)
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        else
            Debug.LogWarning("QuitButton이 연결되지 않았습니다!");

    }

   
    void OnRestartButtonClicked()
    {
        // ✅ 최신 Unity API로 변경 (FindObjectOfType → FindFirstObjectByType)
        KoreanSceneController sc = FindFirstObjectByType<KoreanSceneController>();

        if (sc == null)
        {
            Debug.LogError("⚠ SceneController가 씬에 없습니다! Hierarchy에 추가해주세요.");
            return;
        }

        sc.StartGame(); // 랜덤 씬 순서 생성
    }

    void OnQuitButtonClicked()
    {
        // 게임 종료
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
