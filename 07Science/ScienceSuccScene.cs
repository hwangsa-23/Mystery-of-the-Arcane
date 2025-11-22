using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScienceSucc : MonoBehaviour
{
    [Header("UI")]
    public Button QuitButton;      // 종료 버튼

    void Start()
    {
        if (QuitButton != null)
            QuitButton.onClick.AddListener(OnQuitButtonClicked);
        else
            Debug.LogWarning("QuitButton이 연결되지 않았습니다!");

    }
    public void ClickedSuccQuit()
    {
        SceneManager.LoadScene("06Silheomsil_GetObj");
    }

    void OnQuitButtonClicked()
    {
        SceneManager.LoadScene("06Silheomsil");
    }
}
