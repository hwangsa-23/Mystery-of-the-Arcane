using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HistoryGameManager : MonoBehaviour
{
    [SerializeField] HistoryDropsPanel dropsPanel;

    TextMeshProUGUI[] drops;
    string[] answers;


    void Awake()
    {
        answers = new string[] { "을사늑약 체결", "국권피탈", "3·1운동", "대한민국 임시정부 수립", "한국광복군 창설", "광복" };
    }
    void Start()
    {
        drops = dropsPanel.GetDropsTexts();
        //Debug.Log($"drops count = {drops.Length}");
    }

    public void ClickedCheck()
    {
        int result = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            if (drops[i].text == answers[i])
            {
                result++;
            }
        }
        if ( result == answers.Length )
        {
            if (LibraryGameManager.Instance != null)
            {
                LibraryGameManager.Instance.HistoryCleared = true;
                LibraryGameManager.Instance.JustClearedHistory = true;
            }
            else
            {
                Debug.LogError("LibraryGameManager 인스턴스를 찾을 수 없습니다! 실행 순서를 확인하세요.");
            }
        }
        SceneManager.LoadScene(result == answers.Length ? "HistoryEndingSucc" : "HistoryEndingFail");


    }
}