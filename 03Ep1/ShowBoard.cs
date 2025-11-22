using UnityEngine;
using UnityEngine.UI;

public class ShowBoard : MonoBehaviour
{
    [Header("표시할 게시판 패널")]
    public GameObject boardPanel;     // Canvas 안 Panel

    [Header("닫기 버튼")]
    public Button closeButton;        // Panel 안 close button

    void Start()
    {
        // 처음엔 꺼둔다
        if (boardPanel != null)
            boardPanel.SetActive(false);

        // 닫기 버튼 이벤트 연결
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
    }

    void OnMouseDown()
    {
        // 게시판 열기
        if (boardPanel != null)
            boardPanel.SetActive(true);
    }

    void ClosePanel()
    {
        if (boardPanel != null)
            boardPanel.SetActive(false);
    }
}
