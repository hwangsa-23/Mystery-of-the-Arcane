using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ArtGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject succPanel;
    [SerializeField]
    GameObject failPanel;

    public string answer;
    TextMeshProUGUI optionText;
    //static List<int> randomScene;
    //static int i = 0;
    public static int succ = 0;

    // 보기 클릭
    public void OptionClick()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        optionText = clickedButton.GetComponentInChildren<TextMeshProUGUI>();
        if (optionText.text == answer) //정답을 선택했을 때
        {
            //Debug.Log("정답");
            succ++;
            succPanel.SetActive(true);
            Invoke("NextScene", 1);
        }
        else //틀린 답을 선택했을 때
        {
            //Debug.Log("떙");
            failPanel.SetActive(true);
            Invoke("NextScene", 2);
        }

    }

    //문제를 푼 뒤 다음 문제(씬)으로 넘어가기
    void NextScene()
    {
        if (ArtSceneController.Instance != null)
        {
            ArtSceneController.Instance.LoadNextScene();
        }
        else
        {
            Debug.LogWarning("ArtSceneController Instance가 존재하지 않습니다!");
        }
    }
}

   