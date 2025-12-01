using UnityEngine;

public class SilheomsilOutline : MonoBehaviour
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
