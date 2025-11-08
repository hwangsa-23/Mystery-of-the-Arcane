using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryHint : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject hintButton;
    [SerializeField] RectTransform HintObj;
    float minY = -1000f;
    float maxY = 0f;
    float moveTime = 1.5f;

    public void ClickedExitHint()
    {
        StartCoroutine(MoveDownCoroutine());
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        hintButton.SetActive(true);
    }

    IEnumerator MoveDownCoroutine()
    {
        Vector2 startPos = HintObj.anchoredPosition;
        Vector2 endPos = new Vector2(HintObj.anchoredPosition.x, minY);

        float timeValue = 0f;

        while (timeValue < moveTime)
        {
            timeValue += Time.deltaTime;
            float t = timeValue / moveTime;

            HintObj.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }

        HintObj.gameObject.SetActive(false);
    }

    public void ClickedHint()
    {
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        hintButton.SetActive(false);
        HintObj.gameObject.SetActive(true);
        StartCoroutine(MoveUpCoroutine());
    }

    IEnumerator MoveUpCoroutine()
    {
        Vector2 startPos = HintObj.anchoredPosition;
        Vector2 endPos = new Vector2(HintObj.anchoredPosition.x, maxY);

        float timeValue = 0f;

        while (timeValue < moveTime)
        {
            timeValue += Time.deltaTime;
            float t = timeValue / moveTime;

            HintObj.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }
    }

    public void GoDrag1()
    {
        //대한민국 임시정부 수립
        Application.OpenURL("https://ko.wikipedia.org/wiki/%EB%8C%80%ED%95%9C%EB%AF%BC%EA%B5%AD_%EC%9E%84%EC%8B%9C%EC%A0%95%EB%B6%80");
    }

    public void GoDrag2()
    {
        //을사늑약 체결
        Application.OpenURL("https://ko.wikipedia.org/wiki/%EC%9D%84%EC%82%AC%EC%A1%B0%EC%95%BD");
    }

    public void GoDrag3()
    {
        //광복
        Application.OpenURL("https://ko.wikipedia.org/wiki/%EA%B4%91%EB%B3%B5%EC%A0%88");
    }
    public void GoDrag4()
    {
        //한국광복군 창설
        Application.OpenURL("https://ko.wikipedia.org/wiki/%ED%95%9C%EA%B5%AD_%EA%B4%91%EB%B3%B5%EA%B5%B0");
    }
    public void GoDrag5()
    {
        //3.1운동
        Application.OpenURL("https://ko.wikipedia.org/wiki/3%C2%B71_%EC%9A%B4%EB%8F%99");
    }
    public void GoDrag6()
    {
        //국권피탈
        Application.OpenURL("https://ko.wikipedia.org/wiki/%ED%95%9C%EC%9D%BC%EB%B3%91%ED%95%A9%EC%A1%B0%EC%95%BD");
    }
}
