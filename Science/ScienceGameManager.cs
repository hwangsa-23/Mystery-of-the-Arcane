using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScienceGameManager : MonoBehaviour
{
    [Header("정답 버튼")]
    public Button yes1;
    public Button yes2;

    [Header("오답 버튼")]
    public Button no1;
    public Button no2;

    [Header("UI")]
    public Button nextButton;
    public RectTransform noPage;

    public static int succ = 0;

    private bool yes1Clicked = false;
    private bool yes2Clicked = false;
    private bool wrongClicked = false;

    private float minX = 900f;
    private float maxX = 1450f;
    private float moveTime = 1f;

    void Start()
    {
        // ScienceSceneController가 존재하지 않을 경우 새로 생성
        if (ScienceSceneController.Instance == null)
        {
            GameObject controller = new GameObject("ScienceSceneController");
            controller.AddComponent<ScienceSceneController>();
        }

        // 버튼 클릭 이벤트 등록
        yes1.onClick.AddListener(OnYes1Clicked);
        yes2.onClick.AddListener(OnYes2Clicked);
        no1.onClick.AddListener(OnWrongClicked);
        no2.onClick.AddListener(OnWrongClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);

        // NoPage 초기 위치 설정
        noPage.anchoredPosition = new Vector2(maxX, noPage.anchoredPosition.y);
    }

    void OnYes1Clicked()
    {
        yes1Clicked = true;
        Debug.Log("yes1 버튼 클릭됨");
        CheckAllCorrect();
    }

    void OnYes2Clicked()
    {
        yes2Clicked = true;
        Debug.Log("yes2 버튼 클릭됨");
        CheckAllCorrect();
    }

    void OnWrongClicked()
    {
        if (wrongClicked) return;

        wrongClicked = true;
        Debug.Log("오답 버튼 클릭됨!");
        ShowNoPage();
    }

    void CheckAllCorrect()
    {
        if (yes1Clicked && yes2Clicked && !wrongClicked)
        {
            succ++;
            Debug.Log("정답!");

            if (ScienceSceneController.Instance != null)
                ScienceSceneController.Instance.LoadNextScene();
        }
    }

    void ShowNoPage()
    {
        if (ScienceSceneController.Instance != null && ScienceSceneController.Instance.IsLastScene())
        {
            nextButton.gameObject.SetActive(true);
        }
        StartCoroutine(MoveInCoroutine());
    }

    IEnumerator MoveInCoroutine()
    {
        Vector2 startPos = noPage.anchoredPosition;
        Vector2 endPos = new Vector2(minX, noPage.anchoredPosition.y);

        float time = 0f;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            noPage.anchoredPosition = Vector2.Lerp(startPos, endPos, time / moveTime);
            yield return null;
        }
        noPage.anchoredPosition = endPos;

        if (ScienceSceneController.Instance != null && ScienceSceneController.Instance.IsLastScene())
            Invoke("LoadNextAfterFail", 2f);
    }

    void OnNextButtonClicked()
    {
        if (ScienceSceneController.Instance != null)
            ScienceSceneController.Instance.LoadNextScene();
    }

    void LoadNextAfterFail()
    {
        if (ScienceSceneController.Instance != null)
            ScienceSceneController.Instance.LoadNextScene();
    }

    public void HideNoPage()
    {
        StartCoroutine(MoveOutCoroutine());
    }

    IEnumerator MoveOutCoroutine()
    {
        Vector2 startPos = noPage.anchoredPosition;
        Vector2 endPos = new Vector2(maxX, noPage.anchoredPosition.y);

        float time = 0f;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            noPage.anchoredPosition = Vector2.Lerp(startPos, endPos, time / moveTime);
            yield return null;
        }
        noPage.anchoredPosition = endPos;
    }

    public void ClickedNext()
    {
        if (ScienceSceneController.Instance != null)
        {
            ScienceSceneController.Instance.LoadNextScene();
        }
    }
}
