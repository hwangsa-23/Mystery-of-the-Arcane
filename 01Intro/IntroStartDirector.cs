using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroStartDirector : MonoBehaviour
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
       SceneManager.LoadScene("02SelectEP");
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