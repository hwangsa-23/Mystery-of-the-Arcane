using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System;

public class ClassRoom2Character : MonoBehaviour
{
    [SerializeField] GameObject TalkImage;
    [SerializeField] GameObject otherCharacter1;
    [SerializeField] GameObject otherCharacter2;
    [SerializeField] Button closeButton;
    [SerializeField] GameObject ClaudiaImage;
    [SerializeField] GameObject LisaImage;
    [SerializeField] GameObject LucasImage;
    [SerializeField] GameObject characterName;

    string characterTag;
    bool TF;

    private void OnMouseDown()
    {

        characterTag = gameObject.tag;
        ClassRoom2TalkImage talkImage = TalkImage.GetComponent<ClassRoom2TalkImage>();
        TF = true;
        SetTF(TF);
        talkImage.SetCharacterTag(characterTag);
        ClassRoom2CharacterName c = characterName.GetComponent<ClassRoom2CharacterName>();
        c.SetName(gameObject.tag);

        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();       // 중복 등록 방지
            closeButton.onClick.AddListener(ClickedClose); // this.ClidkedClose 등록
            //closeButton.gameObject.SetActive(true);         // 버튼 표시
        }
        else
        {
            Debug.LogWarning($"{name}: closeButton이 할당되지 않았습니다.");
        }
    }

    public void ClickedClose()
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


        TalkImage.SetActive(TF);
        closeButton.gameObject.SetActive(TF);
        characterName.SetActive(TF);
        SetImage(gameObject.tag);
    }

    void SetImage(string tag)
    {
        if (tag == "Claudia")
            ClaudiaImage.SetActive(TF);
        else if (tag == "Lisa")
            LisaImage.SetActive(TF);
        else if (tag == "Lucas")
            LucasImage.SetActive(TF);

    }
}
