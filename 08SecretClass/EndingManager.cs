using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [SerializeField] GameObject panel;

    [Header("이 오브젝트가 정답인지? (체크하면 정답)")]
    public bool isCorrect = false;

    [Header("엔딩 씬 이름")]
    public string happyEndingScene = "09HappyEnding";
    public string sadEndingScene = "09SadEnding";

    void OnMouseDown()
    {
        // ★ 입력 잠금 중이면 클릭 무효!
        if (SpotlightSequence.inputLocked)
        {
            panel.SetActive(true);
            StartCoroutine(HidePanel());
            Debug.Log("❌ 아직 클릭 불가 (라이트 점등 중)");
            return;
        }

        if (isCorrect)
        {
            Debug.Log("정답 선택 → 해피엔딩");
            SceneManager.LoadScene(happyEndingScene);
        }
        else
        {
            Debug.Log("오답 선택 → 새드엔딩");
            SceneManager.LoadScene(sadEndingScene);
        }
    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);
    }
}
