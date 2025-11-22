using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotlightSequence : MonoBehaviour
{
    [Header("Spotlights (순서대로)")]
    public Light2D[] spotlights;

    [Header("Global Light")]
    public Light2D globalLight;
    public float globalLightDelay = 1f;
    public float globalLightFadeDuration = 1f;

    [Header("Text UI (불 켜진 뒤 보여줄 UI)")]
    public GameObject textUI;
    public GameObject backUI;
    public float textUIDelay = 3f;   // GlobalLight 켜지고 텍스트 켜지는 시점

    [Header("Spotlight settings")]
    public float startDelay = 3f;     
    public float interval = 1f;
    public float fadeDuration = 1f;

    public static bool inputLocked = false;

    void Start()
    {
        // 스포트라이트 intensity = 0
        foreach (var light in spotlights)
            light.intensity = 0f;

        // 글로벌 라이트 꺼두기
        if (globalLight != null)
            globalLight.intensity = 0f;

        // 텍스트 UI도 꺼두기
        if (textUI != null)
            textUI.SetActive(false);
            backUI.SetActive(false);

        inputLocked = true;

        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        //
        // 1️⃣ GlobalLight 페이드인 (1초 뒤)
        //
        yield return new WaitForSeconds(globalLightDelay);

        if (globalLight != null)
            yield return StartCoroutine(FadeInLight(globalLight, globalLightFadeDuration));

        backUI.SetActive(true);
        //
        // 2️⃣ 텍스트 UI 보여주기 (3초 시점)
        //
        yield return new WaitForSeconds(textUIDelay - globalLightDelay);

        if (textUI != null)
            textUI.SetActive(true);

        //
        // 3️⃣ 스포트라이트 순차 페이드인
        //
        yield return new WaitForSeconds(startDelay - textUIDelay);

        foreach (var light in spotlights)
        {
            yield return StartCoroutine(FadeInLight(light, fadeDuration));
            yield return new WaitForSeconds(interval);
        }

        // 4️⃣ 입력 잠금 해제
        inputLocked = false;
    }

    IEnumerator FadeInLight(Light2D light, float duration)
    {
        float t = 0f;
        float target = 1.1f;

        while (t < duration)
        {
            t += Time.deltaTime;
            light.intensity = Mathf.Lerp(0f, target, t / duration);
            yield return null;
        }
    }
}
