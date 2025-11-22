// DoorOutline.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOutline : MonoBehaviour
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

    void OnMouseDown()
    {
    
        SceneManager.LoadScene("03Ep1Corridor");
    }
}
