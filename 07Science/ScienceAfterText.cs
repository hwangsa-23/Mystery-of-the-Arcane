using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScienceAfterText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] GameObject nextButton;
    [SerializeField] Image characterImage; // Fade용 캐릭터 이미지
    [SerializeField] float charPerSeconds = 20f; // 타이핑 속도
    [SerializeField] float fadeTime = 0.5f;       // 이미지 Fade 시간
    [SerializeField] GameObject Panel;
    
    private string[] textArr = new string[5];
    private int t = 0;
    private int index;
    private string targetText;
    private bool isTyping = false;

    void Start()
    {
        // 캐릭터 이미지를 투명하게 설정
        Color c = characterImage.color;
        c.a = 0f;
        characterImage.color = c;

        // 대사 텍스트
        textArr[0] = "모두 조용!";
        textArr[1] = "지금부터 마법 연금술 실기 시험을 시작한다.\n단 한 순간이라도 집중을 놓치면, \n마력의 폭주가 일어날 수 있으니… 각오하도록!";
        textArr[2] = "시험을 시작하기 전에 간단히 설명을 해주겠다.\n설명은 한 번뿐이니, 집중을 흐트러뜨리지 말도록!";
        textArr[3] = "시험 방식은 이렇다. 빈칸에 알맞은 마법의 답을 찾아 클릭하면 된다.\n순서는 내가 배려해 주겠으니, 답에만 집중하도록!";
        textArr[4] = "자, 이제 행운이 너희 곁을 감싸길… \n시험을 시작한다!";


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

        // 텍스트 출력 시작
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

        // 다음 씬으로 이동
        Invoke("NextScene", 0.7f);
    }

    void NextScene()
    {
        SceneManager.LoadScene("ScienceStart");
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
