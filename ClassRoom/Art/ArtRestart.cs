using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtRestart : MonoBehaviour
{
    [SerializeField] private GameObject artSceneControllerPrefab = null;

    public void ClickedRestart()
    {
        if (ArtSceneController.Instance != null)
        {
            ArtSceneController.Instance.GenerateRandomScenes();
            return;
        }
        else
            Debug.Log("ArtSceneController.Instance 비어있음");

        if (artSceneControllerPrefab != null)
        {
            StartCoroutine(InstantiateAndStart());
        }
        else
        {
            Debug.LogWarning("[ArtRestart] 자동 복구용 프리팹이 설정되어 있지 않습니다. 편하신 방법으로 다시 시도해주세요.");
        }
    }

    IEnumerator InstantiateAndStart()
    {
        GameObject go = Instantiate(artSceneControllerPrefab);
        yield return null;

        if (ArtSceneController.Instance != null)
        {
            ArtSceneController.Instance.GenerateRandomScenes();
        }
        else
        {
            Debug.LogError("[ArtRestart] 프리팹 생성 후에도 MathSceneController.Instance가 null입니다. 프리팹에 MathSceneController 스크립트가 붙어있는지 확인하세요.");
        }
    }

    public void ClickedQuit()
    {
        if (ArtSceneController.Instance != null)
            ArtSceneController.Instance.QuitScene();
        else
            Debug.LogError("ArtSceneController.Instance is null");
    }
}
