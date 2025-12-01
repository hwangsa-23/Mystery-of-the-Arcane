using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Button HomeButton;     // 시작 버튼
    public Button QuitButton;      // 종료 버튼

    void Start()
    {
        // 버튼 이벤트 등록
        if (HomeButton != null)
            HomeButton.onClick.AddListener(OnHomeButtonClicked);
        else
            Debug.LogWarning("HomeButton이 연결되지 않았습니다!");

        if (QuitButton != null)
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        else
            Debug.LogWarning("QuitButton이 연결되지 않았습니다!");

    }

   
    void OnHomeButtonClicked()
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