using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LibraryCharacter : MonoBehaviour
{
    [SerializeField] GameObject TalkImage;
    [SerializeField] GameObject otherCharacter1;
    [SerializeField] GameObject otherCharacter2;
    [SerializeField] Button closeButton;
    //[SerializeField] Button nextBtnComp;
    [SerializeField] GameObject ClaudiaImage;
    [SerializeField] GameObject ElinaImage;
    [SerializeField] GameObject LisaImage;
    [SerializeField] GameObject characterName;
    [SerializeField] GameObject characterName2;
    [SerializeField] GameObject books;

    string characterTag;
    bool TF;

    private void OnMouseDown()
    {
        characterTag = gameObject.tag;

        TF = true;
        SetTF(TF);

        if (TalkImage != null)
        {
            LibraryTalkImage talkImage = TalkImage.GetComponent<LibraryTalkImage>();
            if (talkImage != null)
                talkImage.SetCharacterTag(characterTag);
        }
        
        //NextButton.gameObject.SetActive(true);

        if (characterName2 != null)
        {
            LibraryCharacterName2 c = characterName2.GetComponent<LibraryCharacterName2>();
            if (c != null)
                c.SetName(gameObject.tag);
        }

        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();       // 중복 등록 방지
            closeButton.onClick.AddListener(ClickedClose); // this.ClidkedClose 등록
            //closeButton.gameObject.SetActive(true);
            //closeButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning($"{name}: closeButton이 할당되지 않았습니다.");
        }
    }


    public void ClickedClose()
    {
        Image LI = LisaImage.GetComponent<Image>();
        Image CI = ClaudiaImage.GetComponent<Image>();
        LI.color = new Color(1f, 1f, 1f, 01f);
        CI.color = new Color(1f, 1f, 1f, 1f);
        if (TalkImage != null)
            TalkImage.SetActive(false);
        TF = false;
        SetTF(TF);
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.gameObject.SetActive(false);
            characterName.SetActive(false);
            characterName2.SetActive(false);
        }
    }

    void SetTF(bool tf)
    {
        this.TF = tf;

        //False
        //캐릭터들, 책 SetActive(false)
        gameObject.SetActive(!tf);
        otherCharacter1.SetActive(!tf);
        otherCharacter2.SetActive(!tf);
        books.SetActive(!tf);
        
        //True
        TalkImage.SetActive(tf);

        if (characterTag == "Lisa" || characterTag == "Claudia" || characterTag == "Elina")
        {
            characterName2.SetActive(tf);
        }
        if (tf == false)
        {
            SetImage();
        }
        else
        {
            if (characterTag == "Claudia" || characterTag == "Lisa")
            {
                ClaudiaImage.SetActive(TF);
                LisaImage.SetActive(TF);
                ElinaImage.SetActive(!TF);
            }
            else
            {
                ElinaImage.SetActive(TF);
                ClaudiaImage.SetActive(!TF);
                LisaImage.SetActive(!TF);
            }
        }
    }

    //캐릭터들 false
    void SetImage()
    {
        ClaudiaImage.SetActive(TF);
        LisaImage.SetActive(TF);
        ElinaImage.SetActive(TF);
    }
}
