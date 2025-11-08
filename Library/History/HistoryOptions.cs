using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HistoryOptions : MonoBehaviour
{
    public Transform invisibleDragTrans;

    List<HistoryDropsPanel> dropsPanel;

    void Start()
    {
        dropsPanel = new List<HistoryDropsPanel>();
        var arrs = transform.GetComponentsInChildren<HistoryDropsPanel>();
    }

    void Swap(Transform a, Transform b)
    {
        Transform aParent = a.parent;
        Transform bParent = b.parent;

        int aIndex = a.GetSiblingIndex();
        int bIndex = b.GetSiblingIndex();

        a.SetParent(bParent);
        a.SetSiblingIndex(bIndex);
        b.SetParent(aParent);
        b.SetSiblingIndex(aIndex);
    }

    void BeginDrag(Transform dragTrans)
    {
        Debug.Log("BeginDrag: " + dragTrans.name);

        Swap(invisibleDragTrans, dragTrans);
    }
    void Drag(Transform dragTrans)
    {
        Debug.Log("Drag: " + dragTrans.name);
    }
    void EndDrag(Transform dragTrans)
    {
        Debug.Log("EndDrag: " + dragTrans.name);

        Swap(invisibleDragTrans, dragTrans);
    }

}
