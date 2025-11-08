using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;

public class SilheomsilTalkImage : MonoBehaviour
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
        if (tag == "Lucas")
        {
            myText = "난 단지 실험을 성공시키고 싶었을 뿐이야.\n금서는 우연히 내 손에 들어왔어.";
        }
        else if (tag == "Sera")
        {
            myText = "루카스가 실험을 준비하던 걸 알았다\n하지만 그는 허가받지 않은 금서의 문양을 사용했어.";
        }
        else if (tag == "Lisa")
        {
            myText = "클라우디아도 수상하지 않아?";
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
