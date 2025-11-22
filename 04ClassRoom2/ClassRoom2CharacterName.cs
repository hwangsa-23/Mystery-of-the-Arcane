using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassRoom2CharacterName : MonoBehaviour
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
            case "Claudia":
                nameTMP.text = "클라우디아 (범인후보Ⅰ)";
                break;
            case "Lisa":
                nameTMP.text = "리사 (범인후보Ⅱ)";
                break;
            case "Lucas":
                nameTMP.text = "루카스 (범인후보Ⅲ)";
                break;
        }
    }
}
