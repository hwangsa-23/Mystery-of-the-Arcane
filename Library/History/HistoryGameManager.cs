using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HistoryGameManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    HistoryDropsPanel dropsPanel;

    TextMeshProUGUI[] drops;
    string[] answers;


    void Awake()
    {
        answers = new string[] { "을사늑약 체결", "국권피탈", "3·1운동", "대한민국 임시정부 수립", "한국광복군 창설", "광복" };
    }
    void Start()
    {
        if (dropsPanel == null && canvas != null)
            dropsPanel = canvas.GetComponentInChildren<HistoryDropsPanel>(true);

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
        
        if (result == 6)
            SceneManager.LoadScene("HistoryEndingSucc");
        else
            SceneManager.LoadScene("HistoryEndingFail");

        
    }
}