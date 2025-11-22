using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardDirector : MonoBehaviour
{
    [Header("Move Scene Name")]
    public string sceneName;     // Inspector에서 입력

    [Header("추리노트 생성")]
    [SerializeField] ClueSpawner clueSpawner;

    void OnMouseDown()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("⚠ sceneName이 비어있습니다!");
            return;
        }

        clueSpawner.ClueSpawn();

        Debug.Log($"{sceneName} 로 전환");
        SceneManager.LoadScene(sceneName);
    }
}
