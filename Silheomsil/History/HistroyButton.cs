using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistroyButton : MonoBehaviour
{
    public void ClickedRestart()
    {
        //Debug.Log("미니게임 다시 시작");
        SceneManager.LoadScene("HistoryMiniGame");
    }

    public void ClickedQuit()
    {
        //Debug.Log("미니게임 나가기");
        SceneManager.LoadScene("Library");
    }
}
