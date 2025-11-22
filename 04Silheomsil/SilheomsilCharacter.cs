using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SilheomsilCharacter : MonoBehaviour
{
    [SerializeField] GameObject TalkImage;
    [SerializeField] GameObject otherCharacter1;
    [SerializeField] GameObject otherCharacter2;
    [SerializeField] Button closeButton;
    [SerializeField] GameObject LucasImage;
    [SerializeField] GameObject SeraImage;
    [SerializeField] GameObject LisaImage;
    [SerializeField] GameObject characterName;
    [SerializeField] GameObject papers;

    string characterTag;
    bool TF;

    private void OnMouseDown()
    {
        characterTag = gameObject.tag;
        SilheomsilTalkImage talkImage = TalkImage.GetComponent<SilheomsilTalkImage>();
        talkImage.SetCharacterTag(characterTag);
        TF = true;
        SetTF(TF);
        SilheomsilCharacterName c = characterName.GetComponent<SilheomsilCharacterName>();
        c.SetName(gameObject.tag);

        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();       // 중복 등록 방지
            closeButton.onClick.AddListener(ClidkedClose); // this.ClidkedClose 등록
            closeButton.gameObject.SetActive(false);         // 버튼 표시
        }
        else
        {
            Debug.LogWarning($"{name}: closeButton이 할당되지 않았습니다.");
        }
    }

    public void ClidkedClose()
    {
        if (TalkImage != null)
            TalkImage.SetActive(false);
        TF = false;
        SetTF(TF);
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.gameObject.SetActive(false);
        }
    }

    void SetTF(bool TF)
    {
        //False
        gameObject.SetActive(!TF);
        otherCharacter1.SetActive(!TF);
        otherCharacter2.SetActive(!TF);
        papers.SetActive(!TF);
        

        TalkImage.SetActive(TF);
        closeButton.gameObject.SetActive(TF);
        characterName.SetActive(TF);
        SetImage(gameObject.tag);
    }

    //True
    void SetImage(string tag)
    {
        if (tag == "Lucas")
            LucasImage.SetActive(TF);
        else if (tag == "Sera")
            SeraImage.SetActive(TF);
        else if (tag == "Lisa")
            LisaImage.SetActive(TF);

    }

}
