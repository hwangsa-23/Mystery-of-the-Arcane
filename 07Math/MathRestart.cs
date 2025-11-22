using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathRestart : MonoBehaviour
{
    [SerializeField] private GameObject mathSceneControllerPrefab = null;

    public void ClickedRestart()
    {
        if (MathSceneController.Instance != null)
        {
            MathSceneController.Instance.GenerateRandomScenes();
            return;
        }
        else
            Debug.Log("MathSceneController.Instance 비어있음");

        if (mathSceneControllerPrefab != null)
        {
            StartCoroutine(InstantiateAndStart());
        }
        else
        {
            Debug.LogWarning("[MathRestart] 자동 복구용 프리팹이 설정되어 있지 않습니다. 편하신 방법으로 다시 시도해주세요.");
        }
    }

    IEnumerator InstantiateAndStart()
    {
        GameObject go = Instantiate(mathSceneControllerPrefab);
        yield return null;

        if (MathSceneController.Instance != null)
        {
            MathSceneController.Instance.GenerateRandomScenes();
        }
        else
        {
            Debug.LogError("[MathRestart] 프리팹 생성 후에도 MathSceneController.Instance가 null입니다. 프리팹에 MathSceneController 스크립트가 붙어있는지 확인하세요.");
        }
    }


    public void ClickedQuit()
    {
        if (MathSceneController.Instance != null)
            MathSceneController.Instance.QuitScene();
        else
            Debug.LogWarning("[MathRestart] Quit 요청 받음, 그러나 MathSceneController.Instance가 없습니다.");
    }

    public void ClidedSuccQuit()
    {
        SceneManager.LoadScene("06Silheomsil_GetObj");
    }
}
