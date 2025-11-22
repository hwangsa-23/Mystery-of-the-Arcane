using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class MathAfterText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] GameObject nextButton;
    [SerializeField] UnityEngine.UI.Image characterImage; // Fade할 캐릭터 이미지
    [SerializeField] float charPerSeconds = 20f; // 타이핑 속도
    [SerializeField] float fadeTime = 0.5f;       // 이미지 Fade 시간
    [SerializeField] GameObject Panel;
    
    private string[] textArr = new string[3];
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

        //텍스트
        textArr[0] = "집중하거라, 제자들.";
        textArr[1] = "오늘은 마법과 수학의 시험이 기다리고 있다.\n숫자를 두려워하는 자는 이 실험실을 벗어날 수 없지.";
        textArr[2] = "자, 첫 번째 문제를 보도록 하자.";

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
        SceneManager.LoadScene("MathStart");
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
