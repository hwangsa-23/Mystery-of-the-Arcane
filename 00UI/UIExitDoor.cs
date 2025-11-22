using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIExitDoor : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip openSound;

    public void ClickedExitDoor()
    {
        if (audioSource != null && openSound != null)
            audioSource.PlayOneShot(openSound);

        StartCoroutine(PlayThenLoad());
    }

    IEnumerator PlayThenLoad()
    {
        // openSound가 null이 아니므로 openSound.length 사용 가능
        yield return new WaitForSeconds(openSound.length);
        SceneManager.LoadScene("03Ep1Corridor");
    }
}
