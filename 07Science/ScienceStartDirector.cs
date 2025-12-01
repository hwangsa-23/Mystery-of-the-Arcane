using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScienceStartDirector : MonoBehaviour
{
    [Header("UI")]
    public Text GameName;          // 게임 이름 텍스트
    public Button StartButton;     // 시작 버튼
    public Button QuitButton;      // 종료 버튼

    void Start()
    {
        // 버튼 이벤트 등록
        if (StartButton != null)
            StartButton.onClick.AddListener(OnStartButtonClicked);
        else
            Debug.LogWarning("StartButton이 연결되지 않았습니다!");

        if (QuitButton != null)
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        else
            Debug.LogWarning("QuitButton이 연결되지 않았습니다!");

    }

   
    void OnStartButtonClicked()
    {
        // ✅ 최신 Unity API로 변경 (FindObjectOfType → FindFirstObjectByType)
        ScienceSceneController sc = FindFirstObjectByType<ScienceSceneController>();

        if (sc == null)
        {
            Debug.LogError("⚠ ScienceSceneController가 씬에 없습니다! Hierarchy에 추가해주세요.");
            return;
        }

        sc.GenerateRandomScenes(); // 랜덤 씬 순서 생성
        sc.LoadNextScene();        // 첫 번째 게임 씬으로 이동
    }

    void OnQuitButtonClicked()
    {
        SceneManager.LoadScene("06Silheomsil_GetObj");
    }
}
