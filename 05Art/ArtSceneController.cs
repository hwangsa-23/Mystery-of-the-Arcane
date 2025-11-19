using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtSceneController : MonoBehaviour
{
    public static ArtSceneController Instance { get; private set; }
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

    // 게임씬 5개를 모두 랜덤 순서로 섞기
    public void GenerateRandomScenes()
    {
        Debug.Log("버튼 작동 함");

        currentIndex = 0;
        ArtGameManager.succ = 0;

        string currentScene = SceneManager.GetActiveScene().name;

        // 게임씬 리스트 생성
        List<string> allGameScenes = new List<string>
        {
            "ArtJangansa",
            "ArtJangteogil",
            "ArtKyujanggakdo",
            "ArtMudong",
            "ArtNaruteo",
            "ArtSeodang",
            "ArtSonghachwisaengdo",
            "ArtSsireum"
        };

        List<string> candidates = new List<string>();
        foreach (var s in allGameScenes)
        {
            if (s != currentScene)
                candidates.Add(s);
        }

        List<string> randomGameScenes = new List<string>();
        int wantCount = 5;
        wantCount = Mathf.Min(wantCount, candidates.Count);

        // 게임씬 랜덤으로 섞기
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
        int succ = ArtGameManager.succ;
        if (succ >= 3)
            SceneManager.LoadScene("ArtEndingSucc");
        else
            SceneManager.LoadScene("ArtEndingFail");
    }

    //현재 씬이 마지막 씬인지 알려줌
    public bool IsLastScene()
    {
        return currentIndex >= randomSceneOrder.Count;
    }

    public void QuitScene()
    {
        SceneManager.LoadScene("04ClassRoom");
    }

    public void ClickedSuccQuit()
    {
        SceneManager.LoadScene("04ClassRoom_GetObj");
    }
}
