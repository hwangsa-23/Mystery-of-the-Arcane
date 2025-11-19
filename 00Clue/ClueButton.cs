using UnityEngine;

public class ClueButton : MonoBehaviour
{
    [SerializeField] GameObject clueButton;

    private void Update()
    {
        if (ClueSpawner.clueInstance != null && !ClueSpawner.clueInstance.activeSelf)
            clueButton.SetActive(true);
    }

    public void ClickedClueButton()
    {
        if (ClueSpawner.clueInstance == null)
        {
            Debug.LogWarning("아직 추리노트가 생성되지 않았습니다!");
            return;
        }

        //Debug.Log("추리노트 버튼 누름");
        ClueSpawner.clueInstance.SetActive(true);
        clueButton.SetActive(false);

        //Test에 ClueObjBox 전달
        ClueObjBox box = ClueObjBox.Instance;

        MiniGameObjClick miniGameObjClick = FindFirstObjectByType<MiniGameObjClick>();
        if (miniGameObjClick != null) miniGameObjClick.SetClueObjBox(box);
    }
}
