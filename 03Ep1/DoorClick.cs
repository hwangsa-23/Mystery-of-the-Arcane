using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClick : MonoBehaviour
{
    public string sceneName;
    public int doorOrder;

    [Header("Sound")]
    public AudioSource audioSource;     // 오디오 소스
    public AudioClip lockedSound;       // 잠긴 효과음
    public AudioClip openSound;

    void OnMouseDown()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("⚠ Scene Name이 비어 있습니다!");
            return;
        }

        // 🔒 잠긴 문일 때
        if (doorOrder > RoomProgress.unlockedRoom)
        {
            Debug.Log($"🚫 {gameObject.name} 은(는) 잠겨있습니다!");

            // 🔥 잠긴 효과음 재생
            if (audioSource != null && lockedSound != null)
                audioSource.PlayOneShot(lockedSound);

            return;
        }

        // 🔓 문 열림
        if (doorOrder == RoomProgress.unlockedRoom)
        {
            RoomProgress.unlockedRoom++;
        }

        if (audioSource != null && openSound != null)
            audioSource.PlayOneShot(openSound);

        StartCoroutine(PlayThenLoad()); 
    }

    IEnumerator PlayThenLoad()
    {
        // openSound가 null이 아니므로 openSound.length 사용 가능
        yield return new WaitForSeconds(openSound.length);
        SceneManager.LoadScene(sceneName);
    }
}
