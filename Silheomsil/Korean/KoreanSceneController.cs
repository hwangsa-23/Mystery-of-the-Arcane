using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KoreanSceneController : MonoBehaviour
{
    public static KoreanSceneController Instance;

    public static int succ = 0;   // ✅ 정답 카운트
    private List<string> selectedScenes = new List<string>();
    private int currentIndex = 0;

    [Header("UI 버튼")]
    public Button startButton;

    [Header("문제 씬 목록 (총 5개)")]
    public List<string> allGameScenes = new List<string>
    {
        "KoreanMiniGame1",
        "KoreanMiniGame2",
        "KoreanMiniGame3",
        "KoreanMiniGame4",
        "KoreanMiniGame5"
    };

    [Header("최종 결과 씬")]
    public string successScene = "KoreanEndingSucc";
    public string failScene   = "KoreanEndingFail";

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

    void Start()
    {
        // ✅ Start 버튼이 있으면 자동으로 클릭 연결
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();   // 중복 방지
            startButton.onClick.AddListener(StartGame); // 자동 연결
        }
    }

    // ✅ 게임 시작 → 랜덤 3문제 선택
    public void StartGame()
    {
        succ = 0;
        currentIndex = 0;
        selectedScenes.Clear();

        List<string> temp = new List<string>(allGameScenes);

        while (selectedScenes.Count < 3)
        {
            int r = Random.Range(0, temp.Count);
            selectedScenes.Add(temp[r]);
            temp.RemoveAt(r);
        }

        Debug.Log("✅ 선택된 문제: " + string.Join(", ", selectedScenes));
        LoadNextScene();
    }

    // ✅ 다음 씬 로드
    public void LoadNextScene()
    {
        if (currentIndex < selectedScenes.Count)
        {
            string nextScene = selectedScenes[currentIndex];
            currentIndex++;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            LoadResultScene();
        }
    }

    // ✅ 3문제 끝 → 결과 씬
    void LoadResultScene()
    {
        if (succ >= 2)
            SceneManager.LoadScene(successScene);
        else
            SceneManager.LoadScene(failScene);
    }

    // ✅ 마지막 문제 여부
    public bool IsLastScene()
    {
        return currentIndex >= selectedScenes.Count;
    }

}
