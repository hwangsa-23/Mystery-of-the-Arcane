using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardDirector2 : MonoBehaviour
{
    [Header("Move Scene Name")]
    public string sceneName;     // Inspector에서 입력

    void OnMouseDown()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("⚠ sceneName이 비어있습니다!");
            return;
        }


        Debug.Log($"{sceneName} 로 전환");
        SceneManager.LoadScene(sceneName);
    }
}
