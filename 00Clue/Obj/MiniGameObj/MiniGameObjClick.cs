using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObjClick : MonoBehaviour
{
    ClueObjBox clueObjBox;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                HitCheckObject(hit);
            }
        }
    }

    void HitCheckObject(RaycastHit2D hit)
    {
        InterfaceMiniGameObj clickInterface = hit.transform.gameObject.GetComponent<InterfaceMiniGameObj>();

        if (clickInterface != null)
        {
            ClueObj Obj = clickInterface.ClickObj();

            ClueObj mutableClue = ScriptableObject.Instantiate(Obj);

            print($"{mutableClue.name} È¹µæ");

            if (ClueObjBox.Instance != null)
            {
                ClueObjBox.Instance.AddObj(mutableClue);
            }
            else
            {
                Debug.LogError("ClueObjBox ½Ì±ÛÅæÀÌ ÃÊ±âÈ­µÇÁö ¾Ê¾Ò½À´Ï´Ù.");
            }
        }
    }

    public void SetClueObjBox(ClueObjBox box) => clueObjBox = box;
}
