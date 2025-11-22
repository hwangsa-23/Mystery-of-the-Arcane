using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LibraryTalkImage : MonoBehaviour
{
    [SerializeField] GameObject closeButton;
    [SerializeField] GameObject nextButton;
    //[SerializeField] Button nextBtnComp;
    [SerializeField] Image ClaudiaImage;
    [SerializeField] Image LisaImage;
    [SerializeField] GameObject characterName;
    [SerializeField] GameObject characterName2;

    TextMeshProUGUI myTMPro;

    string[] myText;
    int index;
    float charPerSeconds = 20f;
    bool isElina = false;

    //누구랑 대화했는지 확인용
    string TalkWith;


    private void Awake()
    {
        myTMPro = GetComponentInChildren<TextMeshProUGUI>(true);

        if (myTMPro == null)
        {
            Debug.LogError("Awake: TextMeshProUGUI 컴포넌트를 찾을 수 없습니다! 하위 오브젝트 확인.");
        }

        closeButton.SetActive(false);

        //if (gameObject.activeSelf)
        //{
        //    //Debug.Log("대화 시작");
        //    StartTalk();
        //}
    }

    public void SetCharacterTag(string tag)
    {
        StopAllCoroutines();

        TalkWith = tag;
        index = 0;

        if (tag == "Claudia" || tag == "Lisa")
        {
            myText = new string[2];
            //리사
            myText[0] = "나도 금서를 본 적 없어! 오히려 이안이 나를 피했어!";
            //클라우드
            myText[1] = "거짓말! 리사가 금서 근처에 있었잖아. 네가 범인을 감싸는 거야?";
            isElina = false;
        }
        else if (tag == "Elina")
        {
            myText = new string[1];
            myText[0] = "이안이 며칠 전 혼자 금서 보관실에 들어가는 걸 봤어요.";
            isElina = true;
        }

        StartTalk();
    }

    private void OnEnable()
    {
        //StartTalk();
    }


    void StartTalk()
    {
        ShowText();
    }

    void ShowText()
    {
        myTMPro.text = "";
        index = 0;

        if (nextButton != null)
        {
            nextButton.SetActive(myText != null && myText.Length > 1 && !isElina); // next는 대사가 2개 이상일 때만 보임
            var nb = nextButton.GetComponent<Button>();
            if (nb != null) nb.interactable = false; // 처음엔 클릭 불가
        }

        closeButton.SetActive(false);

        StopAllCoroutines();

        if (isElina)
        {
            StartCoroutine(TypeText());
        }
        else
        {
            StartCoroutine(TypeText2());
        }
    }

    //엘리나(사서)만
    IEnumerator TypeText()
    {
        index = 0;
        string sentence = myText[0] ?? "";
        index = 0;
        myTMPro.text = "";

        while (index < sentence.Length)
        {
            myTMPro.text += sentence[index];
            index++;
            yield return new WaitForSeconds(1f / charPerSeconds);
        }
        if (closeButton != null) closeButton.SetActive(true);

    }

    //리사, 클라우디아
    IEnumerator TypeText2()
    {
        if (myText == null || myText.Length == 0)
        {
            Debug.LogError("TypeText2: myText에 대사 내용이 없습니다.");
            yield break;
        }

        Button nextBtnComp = null;
        if (nextButton != null)
            nextBtnComp = nextButton.GetComponent<Button>();
        else
            Debug.LogWarning("TypeText2: nextButton이 할당되지 않았습니다. 다음 버튼 없이 자동 진행합니다.");

        for (int i = 0; i < myText.Length; i++)
            {
                if (i == 0)
                {
                    characterName.SetActive(false);
                    characterName2.SetActive(true);
                    LisaImage.color = new Color(1f, 1f, 1f, 1f);
                    ClaudiaImage.color = new Color(1f, 1f, 1f, 0.2f);
                }
                else
                {
                    characterName.SetActive(true);
                    characterName2.SetActive(false);
                    LisaImage.color = new Color(1f, 1f, 1f, 0.2f);
                    ClaudiaImage.color = new Color(1f, 1f, 1f, 1f);
                }

                nextButton.SetActive(i < myText.Length - 1);
                nextBtnComp.interactable = false;
                closeButton.SetActive(false);

                index = 0;
                myTMPro.text = "";

                while (index < myText[i].Length)
                {
                    myTMPro.text += myText[i][index];
                    index++;
                    yield return new WaitForSeconds(1f / charPerSeconds);
                }

                if (i < myText.Length - 1)
                {
                    bool nextClicked = false;

                    if (nextBtnComp != null)
                    {
                        nextBtnComp.onClick.RemoveAllListeners();
                        nextBtnComp.onClick.AddListener(() => nextClicked = true);

                        nextBtnComp.interactable = true;

                        yield return new WaitUntil(() => nextClicked);

                        nextBtnComp.onClick.RemoveAllListeners();
                        nextBtnComp.interactable = false;
                        if (nextButton != null) nextButton.SetActive(false);
                    }
                    else
                    {
                        // next 버튼이 없으면 자동으로 넘어가도록 짧은 대기 (옵션)
                        yield return new WaitForSeconds(0.5f); // 수정된 부분
                    }
                }
                else
                {
                    // 수정: 마지막 문장 처리
                    nextButton.SetActive(false);
                    closeButton.SetActive(true);
                }
            }
         
        TalkManager.instance.SetActiveLibrary(TalkWith);
    }
}
