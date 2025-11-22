using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SilheomsilCharacterName : MonoBehaviour
{
    TextMeshProUGUI nameTMP;

    private void Awake()
    {
        nameTMP = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetName(string tag)
    {
        switch (tag)
        {
            case "Lucas":
                nameTMP.text = "루카스 (범인후보Ⅲ)";
                break;
            case "Sera":
                nameTMP.text = "세라";
                break;
            case "Lisa":
                nameTMP.text = "리사 (범인후보Ⅱ)";
                break;
        }
    }
}
