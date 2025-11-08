using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class HistoryAfterText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] GameObject nextButton;
    [SerializeField] Image characterImage; // Fade할 캐릭터 이미지
    [SerializeField] float charPerSeconds = 20f; // 타이핑 속도
    [SerializeField] float fadeTime = 0.5f;       // 이미지 Fade 시간
    [SerializeField] GameObject Panel;

    private string[] textArr = new string[4];
    private int t = 0;
    private int index;
    private string targetText;
    private bool isTyping = false;

    void Start()
    {
        // 캐릭터 이미지 알파 0으로 시작
        Color c = characterImage.color;
        c.a = 0f;
        characterImage.color = c;

        // 예시 텍스트
        textArr[0] = "이 도서관의 고서들은 우리 조국의 역사와 지혜를\n고이 간직하고 있느니라.";
        textArr[1] = "오늘, 너희 제자들은 시간 속 사건의 흐름을 바로잡는 시험을 치르게 될 것이다.";
        textArr[2] = "우리나라 독립의 중요한 사건들을 올바른 순서대로\n배열하여, 역사의 흐름을 지켜야 한다.";
        textArr[3] = "조급함을 버리고, 마음을 차분히 다스리거라.\n준비되었는가? 시험을 시작하겠다.";

        // 캐릭터 Fade In 후 텍스트 시작
        StartCoroutine(FadeInCharacter());
    }

    IEnumerator FadeInCharacter()
    {
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

        // 텍스트 보여주기 시작
        ShowText();
    }

    void ShowText()
    {
        targetText = textArr[t];
        myText.text = "";
        index = 0;
        nextButton.SetActive(false);
        isTyping = true;
        StartCoroutine(TypeText());
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
            nextButton.SetActive(false);
            StartCoroutine(FadeOutCharacterAndNextScene());
        }
        else
        {
            nextButton.SetActive(true);
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

        // 씬 이동
        Invoke("nextScene", 0.7f);
    }

    void nextScene()
    {
        SceneManager.LoadScene("HistoryStart");
    }

    public void ClickedText()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            myText.text = targetText;
            isTyping = false;

            if (t == textArr.Length - 1)
            {
                nextButton.SetActive(false);
                StartCoroutine(FadeOutCharacterAndNextScene());
            }
            else
            {
                nextButton.SetActive(true);
            }
        }
        else
        {
            t++;
            if (t < textArr.Length)
            {
                ShowText();
            }
            else
            {
                nextButton.SetActive(false);
            }
        }
    }
}
