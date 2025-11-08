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

        if (QuitButton != null)
            QuitButton.onClick.AddListener(OnQuitButtonClicked);

    }

   
    void OnRestartButtonClicked()
    {
        // ✅ 최신 Unity API로 변경 (FindObjectOfType → FindFirstObjectByType)
        KoreanSceneController sc = FindFirstObjectByType<KoreanSceneController>();

        sc.StartGame(); // 랜덤 씬 순서 생성
    }

    void OnQuitButtonClicked()
    {
        SceneManager.LoadScene("Library");
    }
}
