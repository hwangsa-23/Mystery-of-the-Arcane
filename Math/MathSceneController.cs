using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MathSceneController : MonoBehaviour
{
    public static MathSceneController Instance { get; private set; }
    public static List<string> randomSceneOrder = new List<string>();
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

    // 게임씬 5개를 모두 랜덤 순서로 섞기
    public void GenerateRandomScenes()
    {
        currentIndex = 0;
        MathGameManager.succ = 0;

        string currentScene = SceneManager.GetActiveScene().name;

        // 게임씬 리스트 생성
        List<string> allGameScenes = new List<string>
        {
            "MathMiniGame1",
            "MathMiniGame2",
            "MathMiniGame3",
            "MathMiniGame4",
            "MathMiniGame5",
        };

        List<string> candidates = new List<string>();
        foreach (var s in allGameScenes)
        {
            if (s != currentScene)
                candidates.Add(s);
        }

        List<string> randomGameScenes = new List<string>();
        int wantCount = 3;
        wantCount = Mathf.Min(wantCount, candidates.Count);

        while (randomGameScenes.Count < wantCount)
        {
            int r = Random.Range(0, candidates.Count);
            string pick = candidates[r];
            if (!randomGameScenes.Contains(pick))
            {
                randomGameScenes.Add(pick);
            }
        }

        randomSceneOrder = randomGameScenes;

        Debug.Log("랜덤 순서: " + string.Join(", ", randomSceneOrder));

        LoadNextScene();
    }

    // 다음 씬으로 이동
    public void LoadNextScene()
    {
        while (currentIndex < randomSceneOrder.Count)
        {
            string nextScene = randomSceneOrder[currentIndex];
            currentIndex++;

            if (SceneManager.GetActiveScene().name == nextScene)
            {
                Debug.Log("[LoadNextScene] 다음 씬이 현재 씬과 동일하여 건너뜁니다: " + nextScene);
                continue;
            }

            Debug.Log("[LoadNextScene] 로드: " + nextScene + " (index-> " + currentIndex + ")");
            SceneManager.LoadScene(nextScene);
            return;
        }

        randomSceneOrder.Clear();
        int succ = MathGameManager.succ;
        if (succ >= 2)
            SceneManager.LoadScene("MathEndingSucc");
        else
            SceneManager.LoadScene("MathEndingFail");

    }

    //현재 씬이 마지막 씬인지 알려줌
    public bool IsLastScene()
    {
        return currentIndex >= randomSceneOrder.Count;
    }

    public void QuitScene()
    {
        //Debug.Log("게임 끝!!");
        SceneManager.LoadScene("Silheomsil");
    }
}
