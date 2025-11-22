using UnityEngine;

public class NPCOutline : MonoBehaviour
{
    public GameObject outlineObj;
    public GameObject originalObj;

    SpriteRenderer originalRenderer;

    void Start()
    {
        originalRenderer = originalObj.GetComponent<SpriteRenderer>();

        if (outlineObj)
            outlineObj.SetActive(false); // 처음엔 outline 꺼짐
    }

    void OnMouseEnter()
    {
        if (outlineObj) outlineObj.SetActive(true);
        if (originalRenderer) originalRenderer.enabled = false;  // ❗오브젝트는 살려두고 렌더링만 끔
    }

    void OnMouseExit()
    {
        if (outlineObj) outlineObj.SetActive(false);
        if (originalRenderer) originalRenderer.enabled = true;   // ❗다시 렌더링 켜기
    }
}
