using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameObj : MonoBehaviour, InterfaceMiniGameObj
{
    [Header("오브젝트 이미지")]
    public SpriteRenderer ObjImage;
    [Header("Art 오브젝트")]
    public ClueObj artObj;
    [Header("English 오브젝트")]
    public ClueObj engObj;
    [Header("오브젝트 애니메이터")]
    [SerializeField] Animator ani;
    [Header("Background")]
    [SerializeField] GameObject ObjBackground;

    ClueObj Obj;

    Vector3 originalScale;
    void Awake()
    {
        if (ClassRoomGameManager.Instance.JustClearedArt == true)
        {
            Obj = artObj;
            ClassRoomGameManager.Instance.JustClearedArt = false;
        }
        else if (ClassRoomGameManager.Instance.JustClearedEnglish == true)
        {
            Obj = engObj;
            ClassRoomGameManager.Instance.JustClearedEnglish = false;
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
        SceneManager.LoadScene("04ClassRoom");
    }

}
