using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScienceSceneController : MonoBehaviour
{
    public static ScienceSceneController Instance { get; private set; }
    public List<string> randomSceneOrder = new List<string>();
    private int currentIndex = 0;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    // 랜덤으로 3개의 미니게임 씬 선택
    public void GenerateRandomScenes()
    {
        randomSceneOrder.Clear();
        currentIndex = 0;
        ScienceGameManager.succ = 0;

        // 모든 과학 미니게임 씬
        List<string> allGameScenes = new List<string>
        {
            "ScienceMiniGame1",
            "ScienceMiniGame2",
            "ScienceMiniGame3",
            "ScienceMiniGame4",
            "ScienceMiniGame5",
        };
        List<string> randomGameScenes = new List<string>();

        // 랜덤하게 3개 선택
        while (randomGameScenes.Count < 3)
        {
            int r = Random.Range(0, allGameScenes.Count);
            if (!randomGameScenes.Contains(allGameScenes[r]))
            {
                randomGameScenes.Add(allGameScenes[r]);
            }
        }

        randomSceneOrder = randomGameScenes;

        Debug.Log("선택된 랜덤 씬 순서: " + string.Join(", ", randomSceneOrder));

        LoadNextScene();
    }

    // 다음 씬 로드
    public void LoadNextScene()
    {
        if (currentIndex < randomSceneOrder.Count)
        {
            string nextScene = randomSceneOrder[currentIndex];
            currentIndex++;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            // 마지막 씬 완료 후 결과 화면
            int succ = ScienceGameManager.succ;
            if (succ >= 2)
                SceneManager.LoadScene("ScienceEndingSucc");
            else
                SceneManager.LoadScene("ScienceEndingFail");
        }
    }

    // 마지막 씬인지 확인
    public bool IsLastScene()
    {
        return currentIndex >= randomSceneOrder.Count;
    }

    // 씬 종료
    public void QuitScene()
    {
        SceneManager.LoadScene("Silheomsil");
    }
}
