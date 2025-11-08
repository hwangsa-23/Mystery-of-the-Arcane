using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LibraryCharacterName : MonoBehaviour
{
    TextMeshProUGUI nameTMP;

    private void Awake()
    {
        nameTMP = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetName()
    {
        nameTMP.text = "리사 (범인후보Ⅱ)";
    }
}
