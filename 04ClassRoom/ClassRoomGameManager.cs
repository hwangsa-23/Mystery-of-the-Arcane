using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassRoomGameManager : MonoBehaviour
{
    public static ClassRoomGameManager Instance { get; set; }

    [SerializeField] GameObject artMiniGame;
    [SerializeField] GameObject EnglishMiniGame;

    public bool ArtCleared = false;
    public bool EnglishCleared = false;
    //방금 클리어한 미니게임 확인
    public bool JustClearedArt = false;
    public bool JustClearedEnglish = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새 씬에서 다시 레퍼런스를 찾기
        artMiniGame = GameObject.Find("book");
        EnglishMiniGame = GameObject.Find("board");

        // 상태 적용
        if (ArtCleared && artMiniGame != null)
        {
            artMiniGame.SetActive(false);
        }

        if (EnglishCleared && EnglishMiniGame != null)
        {
            EnglishMiniGame.SetActive(false);
        }
    }
}
