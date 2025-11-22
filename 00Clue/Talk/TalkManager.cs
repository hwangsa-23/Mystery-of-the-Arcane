using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance {  get; private set; }

    [Header("교실(1) 단서들")]
    [SerializeField] GameObject ClassRoom1_1;
    [SerializeField] GameObject ClassRoom1_2;

    [Header("도서관 단서들")]
    [SerializeField] GameObject Library1_1;

    [Header("실험식 단서들")]
    [SerializeField] GameObject Silheomsil1_1;
    [SerializeField] GameObject Silheomsil1_2;

    [Header("교실(2) 단서들")]
    [SerializeField] GameObject ClassRoom2_1;
    [SerializeField] GameObject ClassRoom2_2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetActiveClassRoom1(string tag)
    {
        if (tag == "Lisa")
        {
            ClassRoom1_1.SetActive(true);
        }
        if (tag == "Claudia")
        {
            ClassRoom1_2.SetActive(true);
        }
    }

    public void SetActiveLibrary(string tag)
    {
        if (tag == "Lisa" || tag == "Claudia")
        {
            Library1_1.SetActive(true);
        }
    }

    public void SetActiveSilheomsil(string tag)
    {
        if (tag == "Lucas")
        {
            Silheomsil1_1.SetActive(true);
        }
        if (tag == "Sera")
        {
            Silheomsil1_2.SetActive(true);
        }
    }

    public void SetActiveClassRoom2(string tag)
    {
        if (tag == "Lisa" || tag == "Claudia" || tag == "Lucas")
        {
            ClassRoom2_1.SetActive(true);
            ClassRoom2_2.SetActive(true);
        }
    }
}
