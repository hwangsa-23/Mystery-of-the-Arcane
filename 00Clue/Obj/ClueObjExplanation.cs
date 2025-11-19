using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueObjExplanation : MonoBehaviour
{
    [Header("설명 표시 UI")]
    [SerializeField] Image objImage;
    [SerializeField] TextMeshProUGUI objName;
    [SerializeField] TextMeshProUGUI objExp;

    ClueBox clueBox;

    private void Awake()
    {
        clueBox = GetComponent<ClueBox>();
    }

    public void GetObjTag()
    {
        ClueObj clueObj = clueBox.Obj;

        objImage.sprite = clueObj.ObjImage;
        objName.text = clueObj.ObjName;
        objExp.text = clueObj.ObjExp;

        Debug.Log($"단서 정보 표시: {clueObj.ObjName}");

    }
}
