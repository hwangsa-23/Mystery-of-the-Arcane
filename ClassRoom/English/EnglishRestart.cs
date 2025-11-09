using UnityEngine;

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
        if (EnglishSceneController.Instance != null)
            EnglishSceneController.Instance.QuitScene();
        else
            Debug.LogError("EnglishSceneController.Instance is null");
    }
}
