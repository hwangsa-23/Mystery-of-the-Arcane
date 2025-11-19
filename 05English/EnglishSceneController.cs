using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnglishSceneController : MonoBehaviour
{
    public static EnglishSceneController Instance { get; private set; }
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

    // 랜덤 5개 영어 미니게임 생성
    public void GenerateRandomScenes()
    {
        randomSceneOrder.Clear();
        currentIndex = 0;
        EnglishGameManager.succ = 0;

        // 영어 미니게임 리스트
        List<string> allGameScenes = new List<string>
        {
            "EnglishMiniGame1",
            "EnglishMiniGame2",
            "EnglishMiniGame3",
            "EnglishMiniGame4",
            "EnglishMiniGame5",
        };

        List<string> randomGameScenes = new List<string>();

        // 중복 없이 랜덤 5개
        while (randomGameScenes.Count < 5)
        {
            int r = Random.Range(0, allGameScenes.Count);
            if (!randomGameScenes.Contains(allGameScenes[r]))
            {
                randomGameScenes.Add(allGameScenes[r]);
            }
        }

        randomSceneOrder = randomGameScenes;

        Debug.Log("랜덤 선택: " + string.Join(", ", randomSceneOrder));

        LoadNextScene();
    }

    // 다음 미니게임 로드
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
            // 5개 미니게임 종료 → 성적 씬 이동
            int succ = EnglishGameManager.succ;   // ✅ 수정
            if (succ >= 3)
                SceneManager.LoadScene("EnglishEndingSucc");
            else
                SceneManager.LoadScene("EnglishEndingFail");
        }
    }
    public void StartGame()
{
    // 만약 랜덤 씬 생성이 필요하면
    GenerateRandomScenes();

    // 다음 씬으로 넘어가기
    LoadNextScene();
}


    public void QuitScene()
    {
        //Debug.Log("종료됨!!");
        SceneManager.LoadScene("04ClassRoom");
    }

    public void ClickedSuccQuit()
    {
        SceneManager.LoadScene("04ClassRoom_GetObj");
    }
}
