using UnityEngine;
using UnityEngine.SceneManagement;

public class ClueButton : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject clueButton;

    private void Update()
    {
        // 🚨 씬 로딩 중에는 Update를 실행하지 않도록 방지
        if (!SceneManager.GetActiveScene().isLoaded)
        {
            return;
        }

        // 씬이 로드된 후에도 clueButton이 null인지 다시 한번 확인 (방어 코드)
        if (clueButton == null)
        {
            return;
        }

        // 정상 로직 실행
        if (ClueSpawner.clueInstance != null && !ClueSpawner.clueInstance.activeSelf)
        {
            clueButton.SetActive(true);
        }
    }

    public void ClickedClueButton()
    {
        if (ClueSpawner.clueInstance == null)
        {
            Debug.LogWarning("아직 추리노트가 생성되지 않았습니다!");
            return;
        }

        //Debug.Log("추리노트 버튼 누름");
        ClueSpawner.OpenClue();
        clueButton.SetActive(false);           

        //Test에 ClueObjBox 전달
        ClueObjBox box = ClueObjBox.Instance;

        MiniGameObjClick miniGameObjClick = FindFirstObjectByType<MiniGameObjClick>();
        if (miniGameObjClick != null) miniGameObjClick.SetClueObjBox(box);
    }
}
