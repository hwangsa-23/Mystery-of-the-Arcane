using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HistoryDropsPanel : MonoBehaviour
{
    public TextMeshProUGUI[] GetDropsTexts()
    {
        return GetComponentsInChildren<TextMeshProUGUI>(true); // 자식 전부 즉시 검색
    }
}
