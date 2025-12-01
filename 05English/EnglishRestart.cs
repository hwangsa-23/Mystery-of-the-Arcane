using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnglishRestart : MonoBehaviour
{
    public void ClickedRestart()
    {
        if (EnglishSceneController.Instance != null)
            EnglishSceneController.Instance.GenerateRandomScenes();
        else
            Debug.LogWarning("EnglishSceneController.Instance is null");
    }

    public void ClickedQuit()
    {
        SceneManager.LoadScene("04ClassRoom");
    }

    public void ClickedSuccQuit()
    {
         SceneManager.LoadScene("04ClassRoom_GetObj");
    }
}
