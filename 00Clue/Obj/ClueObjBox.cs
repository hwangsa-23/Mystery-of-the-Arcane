using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueObjBox : MonoBehaviour
{
    public static ClueObjBox Instance { get; private set; }
    public List<ClueObj> Objs;

    [SerializeField] Transform BoxParent;
    [SerializeField] ClueBox[] boxs;

#if UNITY_EDITOR
    private void OnValidate()
    {
        boxs = BoxParent.GetComponentsInChildren<ClueBox>();
    }
#endif
    private void Awake()
    {
        Instance = this;
        FreshBox();
    }

    public void FreshBox() 
    {
        int i = 0;

        for (; i < Objs.Count && i < boxs.Length; i++)
        {
            boxs[i].Obj = Objs[i];
        }
        for (; i < boxs.Length; i++)
        {
            boxs[i].Obj = null;
        }
    }

    public void AddObj(ClueObj _Obj)
    {
        if (Objs.Count < boxs.Length)
        {
            Objs.Add(_Obj);
            FreshBox();
        } else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }
}
