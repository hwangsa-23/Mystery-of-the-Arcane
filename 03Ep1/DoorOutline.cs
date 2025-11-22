// DoorOutline.cs
using UnityEngine;

public class DoorOutline : MonoBehaviour
{
    public GameObject outlineObj;

    void OnMouseEnter()
    {
        if (outlineObj) outlineObj.SetActive(true);
    }

    void OnMouseExit()
    {
        if (outlineObj) outlineObj.SetActive(false);
    }
}
