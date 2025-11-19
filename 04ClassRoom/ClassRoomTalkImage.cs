using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class ClassRoomTalkImage : MonoBehaviour
{
    [SerializeField] GameObject closeButton;
    TextMeshProUGUI myTMPro;
    string myText;
    int index;
    float charPerSeconds = 20f;


    private void Awake()
    {
        myTMPro = GetComponentInChildren<TextMeshProUGUI>(true);

        closeButton.SetActive(false);

        if (gameObject.activeSelf)
        {
            //Debug.Log("대화 시작");
            StartTalk();
        }
    }

    public void SetCharacterTag(string tag)
    {
        if (tag == "Claudia")
        {
            myText = "리사가 이안을 따라다니며 뭔가 훔치려 했다더라.";
        }
        else if (tag == "Lisa")
        {
            myText = "이안은 뭔가 숨기고 있었어.\n며칠 전에도 도서관에서 찾은 게 있다며 웃고 다녔지.";
        }
    }

    private void OnEnable()
    {
        StartTalk();
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
    }
}
