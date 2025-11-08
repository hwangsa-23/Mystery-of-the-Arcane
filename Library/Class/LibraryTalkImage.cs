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
    [SerializeField] Image ClaudiaImage;
    [SerializeField] Image LisaImage;
    [SerializeField] GameObject characterName;
    [SerializeField] GameObject characterName2;
    TextMeshProUGUI myTMPro;
    
    string[] myText;
    int index;
    float charPerSeconds = 20f;
    bool isElina = false;


    private void Awake()
    {
        myTMPro = GetComponentInChildren<TextMeshProUGUI>(true);
        if (myText == null) 
            myText = new string[2];

        closeButton.SetActive(false);

        if (gameObject.activeSelf)
        {
            //Debug.Log("대화 시작");
            StartTalk();
        }
    }

    public void SetCharacterTag(string tag)
    {
        if (tag == "Claudia" || tag == "Lisa")
        {
            if (myText == null) 
                myText = new string[2];
            else if (myText.Length < 2) 
                System.Array.Resize(ref myText, 2);

            //리사
            myText[0] = "나도 금서를 본 적 없어! 오히려 이안이 나를 피했어!";
            //클라우드
            myText[1] = "거짓말! 리사가 금서 근처에 있었잖아. 네가 범인을 감싸는 거야?";
            isElina = false;
        }
        else if (tag == "Elina")
        {
            if (myText == null) 
                myText = new string[1];
            else if (myText.Length < 1) 
                System.Array.Resize(ref myText, 1); ;
            myText[0] = "이안이 며칠 전 혼자 금서 보관실에 들어가는 걸 봤어요.";
            myText[1] = "";
            isElina = true;
        }
    }

    private void OnEnable()
    {
        StartTalk();
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
            StartCoroutine(TypeText2());
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
        if (myText == null) 
            yield break;

        Button nextBtnComp = nextButton.GetComponent<Button>();

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

                nextBtnComp.onClick.RemoveAllListeners();
                nextBtnComp.onClick.AddListener(() => nextClicked = true);

                nextBtnComp.interactable = true;

                yield return new WaitUntil(() => nextClicked);

                nextBtnComp.onClick.RemoveAllListeners();
                nextBtnComp.interactable = false;
                nextButton.SetActive(false);
            }
            else
            {
                // 수정: 마지막 문장 처리
                nextButton.SetActive(false);
                closeButton.SetActive(true);
            }
        }
    }
}
