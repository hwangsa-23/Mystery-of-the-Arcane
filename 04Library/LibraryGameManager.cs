using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryGameManager : MonoBehaviour
{
    public static LibraryGameManager Instance { get; set; }

    [SerializeField] GameObject HistoryMiniGame;
    [SerializeField] GameObject KoreanMiniGame;

    public bool HistoryCleared = false;
    public bool KoreanCleared = false;
    //방금 클리어한 미니게임 확인
    public bool JustClearedHistory = false;
    public bool JustClearedKorean = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새 씬에서 다시 레퍼런스를 찾기
        HistoryMiniGame = GameObject.Find("book1");
        KoreanMiniGame = GameObject.Find("book2");

        // 상태 적용
        if (HistoryCleared && HistoryMiniGame != null)
        {
            HistoryMiniGame.SetActive(false);
        }

        if (KoreanCleared && KoreanMiniGame != null)
        {
            KoreanMiniGame.SetActive(false);
        }
    }
}
