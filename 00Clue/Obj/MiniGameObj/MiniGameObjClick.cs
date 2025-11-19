using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObjClick : MonoBehaviour
{
    ClueObjBox clueObjBox;

    private void Awake()
    {
        clueObjBox = ClueObjBox.Instance;
    }

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

            clueObjBox.AddObj(mutableClue);
        }
    }

    public void SetClueObjBox(ClueObjBox box) => clueObjBox = box;
}
