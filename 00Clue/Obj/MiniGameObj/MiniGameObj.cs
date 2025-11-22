using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameObj : MonoBehaviour, InterfaceMiniGameObj
{
    [Header("오브젝트 이미지")]
    public SpriteRenderer ObjImage;
    [Header("미니게임 오브젝트")]
    public ClueObj Obj1;
    public ClueObj Obj2;
    [Header("오브젝트 애니메이터")]
    [SerializeField] Animator ani;
    [Header("Background")]
    [SerializeField] GameObject ObjBackground;

    ClueObj Obj;
    string goClass;

    Vector3 originalScale;


    // MiniGameObj.cs (Awake 함수 수정)

    void Awake()
    {
        // 🌟 안전 체크 1: ClassRoomGameManager 초기화 확인
        if (ClassRoomGameManager.Instance != null && ClassRoomGameManager.Instance.JustClearedArt == true)
        {
            Obj = Obj1;
            goClass = "04ClassRoom";
            ClassRoomGameManager.Instance.JustClearedArt = false;
        }
        // 🌟 안전 체크 2: ClassRoomGameManager가 여전히 null이 아닐 때만 다음 조건 확인
        else if (ClassRoomGameManager.Instance != null && ClassRoomGameManager.Instance.JustClearedEnglish == true)
        {
            Obj = Obj2;
            goClass = "04ClassRoom";
            ClassRoomGameManager.Instance.JustClearedEnglish = false;
        }
        // 🌟 안전 체크 3: LibraryGameManager 초기화 확인
        else if (LibraryGameManager.Instance != null && LibraryGameManager.Instance.JustClearedHistory == true)
        {
            Obj = Obj1;
            goClass = "05Library";
            LibraryGameManager.Instance.JustClearedHistory = false;
        }
        // 🌟 안전 체크 4: LibraryGameManager가 여전히 null이 아닐 때만 다음 조건 확인
        else if (LibraryGameManager.Instance != null && LibraryGameManager.Instance.JustClearedKorean == true)
        {
            Obj = Obj2;
            goClass = "05Library";
            LibraryGameManager.Instance.JustClearedKorean = false;
        }
        else if (SilheomsilGameManager.Instance != null && SilheomsilGameManager.Instance.JustClearedMath == true)
        {
            Obj = Obj1;
            goClass = "06Silheomsil";
            SilheomsilGameManager.Instance.JustClearedMath = false;
        }
        else if (SilheomsilGameManager.Instance != null && SilheomsilGameManager.Instance.JustClearedScience == true)
        {
            Obj = Obj2;
            goClass = "06Silheomsil";
            SilheomsilGameManager.Instance.JustClearedScience = false;
        }
    }

    void Start()
    {
        ObjBackground.SetActive(false);
        ObjImage.sprite = Obj.ObjImage;

        //Grow에 필요
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(Grow());
    }
    //오브젝트 등장
    IEnumerator Grow()
    {
        float duration = 0.7f; //커지는 시간
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t / duration);
            yield return null;
        }
        transform.localScale = originalScale;
        ObjBackground.SetActive(true);
    }

    //오브젝트 클릭
    public ClueObj ClickObj()
    {
        //Debug.Log("클릭됨");

        ObjBackground.SetActive(false);
        ani.SetBool("isClicked", true);
        return this.Obj;
    }
    //void OnMouseDown()
    //{
    //    Debug.Log("클릭됨");
    //    ani.SetBool("isClicked", true);
    //}

    public void OnAnimFinish()
    {
        ani.SetBool("isClicked", false);
        gameObject.SetActive(false);
        Invoke("GoClass", 0.7f);
    }

    void GoClass()
    {
        SceneManager.LoadScene(goClass);
    }

}
