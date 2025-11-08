using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KoreanGameManager : MonoBehaviour
{
    public static KoreanGameManager Instance;

    [Header("Right")]
    public GameObject effectPanel;
    public Image effectImage;
    public float fadeTime = 1f;

    [Header("Wrong UI")]
    public GameObject rightTextObj;
    public TMP_Text rightText;
    [TextArea] public string wrongMessage;

    [Header("Buttons")]
    public Button yesButton;
    public Button noButton;
    public Button nextButton;

    void Start()
    {
        Instance = this;

        // ?? ?? ?? ?? + ?? 0
        if (effectPanel != null)
            effectPanel.SetActive(false);

        if (effectImage != null)
        {
            Color c = effectImage.color;
            c.a = 0f;
            effectImage.color = c;
        }

        if (rightTextObj != null)
            rightTextObj.SetActive(false);

        if (nextButton != null)
            nextButton.gameObject.SetActive(false);

        // ? ?? ??
        if (yesButton != null)
            yesButton.onClick.AddListener(ClickYES);

        if (noButton != null)
            noButton.onClick.AddListener(ClickNO);

        if (nextButton != null)
            nextButton.onClick.AddListener(OnClickNextButton);
    }

    // ? YES = ??
    public void ClickYES()
    {
        Debug.Log("YES CLICK");

        KoreanSceneController.succ++;

        DisableAnswerButtons();
        StartCoroutine(ShowEffectAndNext());
    }

    // ? NO = ??
    public void ClickNO()
    {
        Debug.Log("NO CLICK");

        DisableAnswerButtons();

        if (rightTextObj != null)
            rightTextObj.SetActive(true);

        if (rightText != null)
            rightText.text = wrongMessage;

        if (nextButton != null)
            nextButton.gameObject.SetActive(true);
    }

    // ? yes, no ?? ????
    void DisableAnswerButtons()
    {
        if (yesButton != null)
            yesButton.interactable = false;

        if (noButton != null)
            noButton.interactable = false;
    }

    // ? ?? ?? + ??? ??
    IEnumerator ShowEffectAndNext()
    {
        Debug.Log("ShowEffect Begin");

        if (effectPanel != null)
            effectPanel.SetActive(true);

        if (effectImage != null)
        {
            Color c = effectImage.color;
            c.a = 0f;
            effectImage.color = c;

            float t = 0f;
            while (t < fadeTime)
            {
                t += Time.deltaTime;
                c.a = Mathf.Lerp(0f, 1f, t / fadeTime);
                effectImage.color = c;
                yield return null;
            }
        }

        // 0.4? ????? ?? ?
        yield return new WaitForSeconds(0.4f);
        LoadNextScene();
    }

    public void OnClickNextButton()
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        if (KoreanSceneController.Instance != null)
        {
            KoreanSceneController.Instance.LoadNextScene();
        }
        else
        {
            Debug.LogError("? KoreanSceneController Instance? NULL ???! ?? KoreanSceneController? ??? ?????.");
        }
    }
}
