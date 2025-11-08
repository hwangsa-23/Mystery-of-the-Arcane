using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MathGameManager : MonoBehaviour
{
    //통합o
    [SerializeField] GameObject answerObj;
    [SerializeField] GameObject yes;
    [SerializeField] GameObject no;
    [SerializeField] GameObject nextButton;
    [SerializeField] RectTransform noPage;

    public static int succ = 0;
    bool isClicked = false;
    float minX = 900f;
    float maxX = 1450f;
    float moveTime = 1f;

    //정답확인 버튼 클릭
    public void ClickedButton()
    {
        if (isClicked)
            return;

        GameObject clickedObj = EventSystem.current.currentSelectedGameObject;

        if (clickedObj != null)
        {
            isClicked = true;
            if (clickedObj == answerObj)
            {
                succ++;
                //Debug.Log("정답입니다~~");
                yes.SetActive(true);

                if (MathSceneController.Instance != null)
                    MathSceneController.Instance.LoadNextScene();
            }
            else
            {
                //Debug.Log("ㄴㄴ틀림~~");
                no.SetActive(true);
                InNoPage();
            }
        }
        else
        {
            Debug.Log("선택안됨!!! 비어있음!!!!");
;        }
    }

    //NoPage IN
    void InNoPage()
    {
        if (MathSceneController.Instance != null && MathSceneController.Instance.IsLastScene())
        {
            nextButton.SetActive(false);
        }
        StartCoroutine(MoveInCoroutine());
    }

    IEnumerator MoveInCoroutine()
    {
        Vector2 startPos = noPage.anchoredPosition;
        Vector2 endPos = new Vector2(minX, noPage.anchoredPosition.y);

        float timeValue = 0f;

        while (timeValue < moveTime)
        {
            timeValue += Time.deltaTime;
            float t = timeValue / moveTime;

            noPage.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }

        if (MathSceneController.Instance != null && MathSceneController.Instance.IsLastScene())
            Invoke("IsLastNext", 2f);
    }

    void IsLastNext()
    {
        MathSceneController.Instance.LoadNextScene();
    }

    //NoPage Out
    void OutNoPage()
    {
        StartCoroutine(MoveOutCoroutine());
    }

    IEnumerator MoveOutCoroutine()
    {
        Vector2 startPos = noPage.anchoredPosition;
        Vector2 endPos = new Vector2(maxX, noPage.anchoredPosition.y);

        float timeValue = 0f;

        while (timeValue < moveTime)
        {
            timeValue += Time.deltaTime;
            float t = timeValue / moveTime;

            noPage.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
    }

    //NoPage의 Next 버튼 클릭
    public void ClickedNext()
    {
        OutNoPage();

        if (MathSceneController.Instance != null)
        {
            Invoke("LNS", moveTime);
        }
        else
        {
            Debug.LogWarning("MathSceneController Instance가 존재하지 않습니다!");
        }
    }

    void LNS()
    {
        MathSceneController.Instance.LoadNextScene();
    }

}
