using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HistoryDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Canvas canvas;
    RectTransform rt;
    CanvasGroup canvasGroup;
    Vector2 pos;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        pos = rt.position;
        canvasGroup.alpha = 0.9f;
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

        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<HistoryDrop>() == null)
        {
            rt.position = pos;
        }
    }
}
