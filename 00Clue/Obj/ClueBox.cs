using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClueBox : MonoBehaviour, IPointerClickHandler
{
    [Header("이미지 컴포넌트")]
    [SerializeField] Image image;

    private ClueObj _Obj;

    public ClueObj Obj
    {
        get { return _Obj; }
        set {
            _Obj = value;
            if (_Obj != null)
            {
                image.sprite = Obj.ObjImage;
                image.color = new Color(1, 1, 1, 1);
            } else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClueObjExplanation explanation = GetComponent<ClueObjExplanation>();
        explanation.GetObjTag();
    }
}
