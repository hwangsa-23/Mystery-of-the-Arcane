using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueSpawner : MonoBehaviour
{
    [SerializeField] GameObject cluePrefab;
    public static GameObject clueInstance; // 이미 생성된 추리노트 유무 확인용

    public void ClueSpawn()
    {
        if (clueInstance != null)
        {
            Debug.Log("이미 추리노트가 존재합니다.");
            return;
        }

        //추리노트 생성
        clueInstance = Instantiate(cluePrefab);
        clueInstance.name = "Clue_Instance";

        DontDestroyOnLoad(clueInstance);
        clueInstance.SetActive(false);

        Debug.Log("추리노트 생성 완료");
    }
}
