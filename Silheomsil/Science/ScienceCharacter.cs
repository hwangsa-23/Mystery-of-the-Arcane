using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MathCharacter : MonoBehaviour
{
    //이미지가 서서히 생기게;
    [SerializeField] Image charac;
    [SerializeField] float time = 1f;

    void Start()
    {
        Color c = charac.color;
        c.a = 0f;
        charac.color = c;

        StartCoroutine(AlphaIn());
    }

    System.Collections.IEnumerator AlphaIn()
    {
        float timer = 0f;
        Color c = charac.color;

        while (timer < time)
        {
            timer += Time.deltaTime;
            c.a = timer / time;
            charac.color = c;
            yield return null;
        }

        c.a = 1f;
        charac.color = c;
    }

    public IEnumerator AlphaOut()
    {
        float timer = 0f;
        Color c = charac.color;
        float startAlpha = c.a;

        while (timer < time)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(startAlpha, 0f, timer / time);
            charac.color = c;
            yield return null;
        }

        c.a = 0f;
        charac.color = c;
    }
}
