using UnityEngine;
using UnityEngine.UI;

public class ClueMarkButton : MonoBehaviour
{
    [Header("첫 페이지")] public GameObject FirstPage;
    [Header("오브젝트 단서 페이지")] public GameObject ObjectPage;
    [Header("대화 단서 페이지")] public GameObject TalkPage;
    [Header("교실 버튼들")]
    //public Button Class1Button;
    //public Button LibraryButton;
    //public Button SilheomsilButton;
    //public Button Class2Button;
    public CanvasGroup classGroup;
    [Header("교실 페이지들")]
    public GameObject ClassRoom1Page;
    public GameObject LibraryPage;
    public GameObject SilheomsilPage;
    public GameObject ClassRoom2Page;

    private void Awake()
    {
        FirstPage.SetActive(true);
        ObjectPage.SetActive(false);
        TalkPage.SetActive(false);
        ClassSetActiveF();
        DisableButtonClick();
    }

    //Red Mark
    public void ClickedQuitButton()
    {
        if (ClueSpawner.clueInstance != null)
        {
            FirstPage.SetActive(true);
            ObjectPage.SetActive(false);
            TalkPage.SetActive(false);
            ClassSetActiveF();
            DisableButtonClick();
            ClueSpawner.CloseClue(); // UI 비활성화
        }
    }

    //Blue Mark
    public void ClickObjectButton()
    {
        //Debug.Log("오브젝트 버튼 눌림");
        FirstPage.SetActive(false);
        ObjectPage.SetActive(true);
        TalkPage.SetActive(false);
        ClassSetActiveF();
        DisableButtonClick();
    }

    //Green Mark
    public void ClickedTalkButton()
    {
        //Debug.Log("대화 버튼 누름");
        FirstPage.SetActive(false);
        ObjectPage.SetActive(false);
        TalkPage.SetActive(true);
        ClassRoom1Page.SetActive(true);
        EnableButtonClick();
    }

    public void ClickedClass1Button()
    {
        //Debug.Log("교실1버튼 누름");
        ClassRoom1Page.SetActive(true);
        LibraryPage.SetActive(false);
        SilheomsilPage.SetActive(false);
        ClassRoom2Page.SetActive(false);
    }
    public void ClickedLibraryButton()
    {
        //Debug.Log("도서관 버튼 누름");
        ClassRoom1Page.SetActive(false);
        LibraryPage.SetActive(true);
        SilheomsilPage.SetActive(false);
        ClassRoom2Page.SetActive(false);
    }

    public void ClickedSilheomsilButton()
    {
        //Debug.Log("실험실 버튼 누름");
        ClassRoom1Page.SetActive(false);
        LibraryPage.SetActive(false);
        SilheomsilPage.SetActive(true);
        ClassRoom2Page.SetActive(false);
    }

    public void ClickedClassRoom2Button()
    {
        //Debug.Log("교실(2) 버튼 누름");
        ClassRoom1Page.SetActive(false);
        LibraryPage.SetActive(false);
        SilheomsilPage.SetActive(false);
        ClassRoom2Page.SetActive(true);
    }

    void ClassSetActiveF()
    {
        ClassRoom1Page.SetActive(false);
        LibraryPage.SetActive(false);
        SilheomsilPage.SetActive(false);
        ClassRoom2Page.SetActive(false);
    }

    public void DisableButtonClick()
    {
        //Class1Button.interactable = false;
        //LibraryButton.interactable = false;
        //SilheomsilButton.interactable = false;
        //Class2Button.interactable= false;
        classGroup.blocksRaycasts = false;
    }

    public void EnableButtonClick()
    {
        //Class1Button.interactable = true;
        //LibraryButton.interactable = true;
        //SilheomsilButton.interactable = true;
        //Class2Button.interactable = true;
        classGroup.blocksRaycasts = true;
    }
}
