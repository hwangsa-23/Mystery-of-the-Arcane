using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnglishAfterText : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] GameObject nextButton;
    [SerializeField] Image characterImage; 
    [SerializeField] GameObject Panel;

    [Header("Settings")]
    [SerializeField] float charPerSeconds = 20f;
    [SerializeField] float fadeTime = 0.5f;

    private string[] textArr = new string[4];
    private int t = 0;
    private int index = 0;
    private string targetText = "";
    private bool isTyping = false;
    Coroutine typingCoroutine;

    void Awake()
    {
        // nextButton 자동 탐색
        if (nextButton == null)
            nextButton = GameObject.Find("NextButton");

        // Text 자동 탐색
        if (myText == null)
            myText = FindFirstObjectByType<TextMeshProUGUI>();

        // Image 자동 탐색
        if (characterImage == null)
            characterImage = FindFirstObjectByType<Image>();
    }

    void Start()
    {
        // ✅ nextButton 클릭 이벤트 연결
        if (nextButton != null)
        {
            Button btn = nextButton.GetComponent<Button>();
            if (btn != null)
                btn.onClick.AddListener(ClickedText);
        }

        // 캐릭터 이미지 알파=0
        if (characterImage != null)
        {
            Color c = characterImage.color;
            c.a = 0f;
            characterImage.color = c;
        }

        // 텍스트 데이터
        textArr[0] = "안녕! \n지금부터 마법 문서 해독 시험이 시작돼.";
        textArr[1] = "주어진 문장을 읽고 알맞은 답을 선택하면 돼!";
        textArr[2] = "어쩌면 시험 속 문장 중엔… \n너의 고민에 길을 비춰줄 문장이 \n숨겨져 있을지도 모르지.";
        textArr[3] =  "그럼, 합격을 향해 함께 나아가 보자.";

        // Fade + Text start
        StartCoroutine(FadeInCharacter());
    }

    IEnumerator FadeInCharacter()
    {
        if (characterImage == null)
        {
            Debug.LogError("characterImage가 null입니다!");
            yield break;
        }

        float timer = 0f;
        Color c = characterImage.color;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, timer / fadeTime);
            characterImage.color = c;
            yield return null;
        }

        c.a = 1f;
        characterImage.color = c;

        if (Panel != null)
            Panel.SetActive(true);

        ShowText();
    }

    void ShowText()
    {
        if (t >= textArr.Length)
            return;

        targetText = textArr[t];
        myText.text = "";
        index = 0;
        nextButton?.SetActive(false);
        isTyping = true;

        typingCoroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (index < targetText.Length)
        {
            myText.text += targetText[index];
            index++;
            yield return new WaitForSeconds(1f / charPerSeconds);
        }

        isTyping = false;

        if (t == textArr.Length - 1)
        {
            nextButton?.SetActive(false);
            StartCoroutine(FadeOutCharacterAndNextScene());
        }
        else
        {
            nextButton?.SetActive(true);
        }
    }

    IEnumerator FadeOutCharacterAndNextScene()
    {
        float timer = 0f;
        Color c = characterImage.color;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, timer / fadeTime);
            characterImage.color = c;
            yield return null;
        }

        c.a = 0f;
        characterImage.color = c;

        yield return new WaitForSeconds(0.7f);

        SceneManager.LoadScene("EnglishStart");
    }

    public void ClickedText()
    {
        if (isTyping)
        {
            // 즉시 전체 출력
            isTyping = false;

            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            myText.text = targetText;

            if (t == textArr.Length - 1)
            {
                nextButton?.SetActive(false);
                StartCoroutine(FadeOutCharacterAndNextScene());
            }
            else
            {
                nextButton?.SetActive(true);
            }
        }
        else
        {
            // 다음 텍스트
            t++;
            if (t < textArr.Length)
            {
                ShowText();
            }
            else
            {
                nextButton?.SetActive(false);
            }
        }
    }
}
