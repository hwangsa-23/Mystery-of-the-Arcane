using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnglishGameManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject succPanel;   // 정답 패널
    [SerializeField] private GameObject wrongPanel;  // 오답 패널 (Canvas/Book/WrongPanel)

    [Header("Wrong Panel Next Button")]
    [SerializeField] private GameObject nextButton;  // WrongPanel/NextButton

    [Header("Buttons (옵션: 비워두면 자동 탐색)")]
    [SerializeField] private Button yesButton;       // Canvas/Book/Question/yesButton
    [SerializeField] private Button[] noButtons;     // Canvas/Book/Question/noButton1~3

    public static int succ = 0;

    void Awake()
    {
        // ---- 패널/버튼 자동 탐색 (이름 기준) ----
        if (wrongPanel == null)
            wrongPanel = GameObject.Find("WrongPanel");

        if (succPanel == null)
            succPanel = GameObject.Find("succPanel");

        // NextButton
        if (wrongPanel != null && nextButton == null)
        {
            var t = wrongPanel.transform.Find("NextButton");
            if (t != null) nextButton = t.gameObject;
        }

        // yesButton
        if (yesButton == null)
        {
            var go = GameObject.Find("yesButton");
            if (go) yesButton = go.GetComponent<Button>();
        }

        // noButtons 자동 수집
        if (noButtons == null || noButtons.Length == 0)
        {
            noButtons = GameObject.FindObjectsByType<Button>(FindObjectsSortMode.None)
                .Where(b => b.name.StartsWith("noButton"))
                .ToArray();
        }
    }

    void Start()
    {
        // ---- 버튼 이벤트 등록 ----
        if (yesButton != null)
            yesButton.onClick.AddListener(OnYesClick);

        foreach (var btn in noButtons)
            if (btn != null)
                btn.onClick.AddListener(OnNoClick);

        // ---- 시작 시 패널 숨김 ----
        if (succPanel != null) succPanel.SetActive(false);
        if (wrongPanel != null) wrongPanel.SetActive(false);

        if (nextButton != null)
        {
            var nb = nextButton.GetComponent<Button>();
            if (nb != null) nb.onClick.AddListener(OnWrongNextClick);
            nextButton.SetActive(false);
        }

        // ---- 진단 로그 ----
        Debug.Log($"[EnglishGameManager] Init " +
                  $"succPanel={(succPanel ? "OK" : "NULL")}, " +
                  $"wrongPanel={(wrongPanel ? "OK" : "NULL")}, " +
                  $"nextButton={(nextButton ? "OK" : "NULL")}, " +
                  $"yesButton={(yesButton ? "OK" : "NULL")}, " +
                  $"noButtons={noButtons?.Length ?? 0}");
    }

    // ✅ 정답
    public void OnYesClick()
    {
        succ++;

        if (succPanel)
            succPanel.SetActive(true);

        Invoke(nameof(NextScene), 1f);
    }

    // ❌ 오답
    public void OnNoClick()
    {
        if (wrongPanel == null)
        {
            Debug.LogError("[EnglishGameManager] ❌ wrongPanel 참조가 없습니다. 오브젝트 이름이 'WrongPanel'인지 확인하세요.");
            return;
        }

        wrongPanel.SetActive(true);
        wrongPanel.transform.SetAsLastSibling();

        // CanvasGroup 처리
        var cg = wrongPanel.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = 1f;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }

        // Next 버튼 표시
        if (nextButton != null)
            nextButton.SetActive(true);

        // UI 위치/스케일 문제 방지
        var rt = wrongPanel.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.localScale = Vector3.one;
            rt.anchoredPosition = Vector2.zero;
        }

        Debug.Log("[EnglishGameManager] ❗ WrongPanel 활성화됨.");
    }

    public void OnWrongNextClick() => NextScene();

    void NextScene()
    {
        if (EnglishSceneController.Instance != null)
            EnglishSceneController.Instance.LoadNextScene();
        else
            Debug.LogWarning("⚠ EnglishSceneController Instance가 존재하지 않습니다!");
    }
}
