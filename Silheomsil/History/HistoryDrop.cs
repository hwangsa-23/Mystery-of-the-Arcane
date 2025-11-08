using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HistoryDrop : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    TextMeshProUGUI dropText;
    Transform root;

    Canvas canvas;
    RectTransform rt;
    CanvasGroup canvasGroup;
    Vector2 pos;

    void Awake()
    {
        dropText = GetComponentInChildren<TextMeshProUGUI>();
        root = transform.root;

        rt = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragObj = eventData.pointerDrag;
        TextMeshProUGUI dragText = dragObj.GetComponentInChildren<TextMeshProUGUI>();

        if (dragObj != null)
        {
            //Debug.Log("드랍 성공임~~");
            if (dragObj.CompareTag("Drag") && dropText.text == "" )
            {
                dropText.text = dragText.text;
                dragObj.SetActive(false);
            }
            else if (dragObj.CompareTag("Drag") && dropText.text != "")
            {
                string temp = dropText.text;
                dropText.text = dragText.text;
                dragText.text = temp;
            }
            else if (gameObject.CompareTag("Drop") && dragObj.CompareTag("Drop"))
            {
                string temp = dropText.text;
                dropText.text = dragText.text;
                dragText.text = temp;
            }
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        pos = rt.position;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        rt.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        rt.position = pos;
    }
}
