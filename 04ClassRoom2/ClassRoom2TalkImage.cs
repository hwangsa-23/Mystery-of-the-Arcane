using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class ClassRoom2TalkImage : MonoBehaviour
{
    [SerializeField] GameObject closeButton;
    TextMeshProUGUI myTMPro;
    string myText;
    int index;
    float charPerSeconds = 20f;

    //누구랑 대화했는지 확인용
    string TalkWith;

    private void Awake()
    {
        myTMPro = GetComponentInChildren<TextMeshProUGUI>(true);

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
        if (tag == "Claudia")
        {
            myText = "너도 알겠지? 루카스는 이안을 질투했어.\n하지만… 나도 그때 도서관에 있었어.";
        }
        else if (tag == "Lisa")
        {
            myText = "너도 뭔가 알고 있지?\n금서가 사라진 그날 밤, 어디 있었어?";
        }
        else if (tag == "Lucas")
        {
            myText = "클라우디아도 믿지 마.\n그녀가 모든 걸 조종했어.";
        }

        StartTalk();
    }

    private void OnEnable()
    {
        //StartTalk();
    }


    public void StartTalk()
    {
        ShowText();
    }

    void ShowText()
    {
        myTMPro.text = "";
        index = 0;
        closeButton.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        while (index < myText.Length)
        {
            myTMPro.text += myText[index];
            index++;
            yield return new WaitForSeconds(1f / charPerSeconds);
        }

        closeButton.SetActive(true);

        TalkManager.instance.SetActiveClassRoom2(TalkWith);
    }
}
