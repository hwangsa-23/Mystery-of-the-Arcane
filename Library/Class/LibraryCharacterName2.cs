using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LibraryCharacterName2 : MonoBehaviour
{
    TextMeshProUGUI nameTMP;

    private void Awake()
    {
        nameTMP = GetComponentInChildren<TextMeshProUGUI>(true);
    }
    public void SetName(string tag)
    {
        if (nameTMP == null)
        {
            nameTMP = GetComponentInChildren<TextMeshProUGUI>(true);
            if (nameTMP == null) return;
        }

        switch (tag)
        {
            case "Claudia":
            case "Lisa":
                nameTMP.text = "리사 (범인후보Ⅱ)";
                break;
            case "Elina":
                nameTMP.text = "엘리나";
                break;
            default:
                break;
        }
    }
}
