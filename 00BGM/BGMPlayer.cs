using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BGMPlayer : MonoBehaviour
{
    [Header("BGM")]
    public AudioClip introBGM;
    public AudioClip corridorBGM;
    public AudioClip classRoomBGM;
    public AudioClip libraryBGM;
    public AudioClip lapBGM;
    public AudioClip selectBGM;
    public AudioClip HappyEndingBGM;

    private static BGMPlayer instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.loop = true;
            }

            // 씬 변경 감시 등록
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip nextClip = null;

        switch (scene.name)
        {
            case "01Intro":
                nextClip = introBGM;
                break;
            case "03Ep1Corridor":
                nextClip = corridorBGM;
                break;
            case "04ClassRoom":
            case "07ClassRoom2":
                nextClip = classRoomBGM;
                break;
            case "05Library":
                nextClip = libraryBGM;
                break;
            case "06Silheomsil":
                nextClip = lapBGM;
                break;
            case "08Choice":
                nextClip = selectBGM;
                break;
            case "09HappyEnding":
                nextClip = HappyEndingBGM;
                break;
        }

        if (nextClip == null)
            return;

        if (scene.name == "01Intro")
        {
            EnsureVideoHasAudioSource();
            PlayClip(nextClip);
            return;
        }

        PlayClip(nextClip);

    }

    private void PlayClip(AudioClip clip)
    {
        if (clip == null) return;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.loop = true;
            }
        }

        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = 1f;
        audioSource.Play();
    }

    void EnsureVideoHasAudioSource()
    {
        VideoPlayer vp = FindFirstObjectByType<VideoPlayer>();

        if (vp == null) return;

        vp.audioOutputMode = VideoAudioOutputMode.AudioSource;

        AudioSource videoSrc = vp.GetComponent<AudioSource>();
        if (videoSrc == null)
        {
            videoSrc = vp.gameObject.AddComponent<AudioSource>();
            videoSrc.playOnAwake = false;
            videoSrc.spatialBlend = 0f; 
            videoSrc.volume = 0.6f;
        }

        vp.SetTargetAudioSource(0, videoSrc);

        if (!vp.isPlaying)
        {
            vp.Play();
        }
    }
}