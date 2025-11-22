using UnityEngine;
using UnityEngine.SceneManagement;

public class SilheomsilGameManager : MonoBehaviour
{
    public static SilheomsilGameManager Instance { get; set; }

    [SerializeField] GameObject MathMiniGame;
    [SerializeField] GameObject ScienceMiniGame;

    public bool MathCleared = false;
    public bool ScienceCleared = false;
    //방금 클리어한 미니게임 확인
    public bool JustClearedMath = false;
    public bool JustClearedScience = false;

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
        MathMiniGame = GameObject.Find("book1");
        ScienceMiniGame = GameObject.Find("book2");

        // 상태 적용
        if (MathCleared && MathMiniGame != null)
        {
            MathMiniGame.SetActive(false);
        }

        if (ScienceCleared && ScienceMiniGame != null)
        {
            ScienceMiniGame.SetActive(false);
        }
    }
}
