using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int succ;

    void Awake()
    {
        succ = ArtGameManager.succ;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreText.text = succ.ToString() + " / 5";
    }
}
