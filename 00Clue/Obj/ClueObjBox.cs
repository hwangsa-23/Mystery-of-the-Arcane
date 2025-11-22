using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueObjBox : MonoBehaviour
{
    private static ClueObjBox _instance;

    public static ClueObjBox Instance
    {
        get
        {
            if (_instance == null)
            {
                // 씬 전체에서 ClueObjBox 컴포넌트를 찾습니다.
                _instance = FindAnyObjectByType<ClueObjBox>(FindObjectsInactive.Include); // (true)는 비활성화된 오브젝트도 검색

                if (_instance == null)
                {
                    Debug.LogError("ClueObjBox 인스턴스를 씬에서 찾을 수 없습니다. 오브젝트가 존재하는지 확인하세요.");
                }
                else
                {
                    // 비활성화 상태였다면, 활성화하여 Awake() 및 Start()가 실행되도록 유도합니다.
                    // (버튼 클릭 대신 최초 접근 시 활성화)
                    if (!_instance.gameObject.activeInHierarchy)
                    {
                        _instance.gameObject.SetActive(true);
                        Debug.Log("ClueObjBox가 비활성화 상태에서 즉시 활성화되었습니다.");
                    }
                }
            }
            return _instance;
        }
    }

    //public static ClueObjBox Instance { get; private set; }
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
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

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
            print("슬롯이 가득 차 있습니다.");
        }
    }
}
