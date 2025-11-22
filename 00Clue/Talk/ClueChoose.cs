using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueChoose : MonoBehaviour
{
    Transform myTransform;
    private void Start()
    {
        myTransform = GetComponent<Transform>();

        gameObject.SetActive(false);
    }

    //선택지 클릭
    public void ClickedC1()
    {
        //Debug.Log("리사 클릭");
        myTransform.localPosition = Vector3.zero;
        gameObject.SetActive(true);
    }

    public void ClickedC2()
    {
        //Debug.Log("클라우디아 클릭");
        myTransform.localPosition = new Vector3(0, -130, 0);
        gameObject.SetActive(true);
    }

    public void ClickedC3()
    {
        //Debug.Log("루카스 클릭");
        myTransform.localPosition = new Vector3(0, -265, 0);
        gameObject.SetActive(true);
    }
}
