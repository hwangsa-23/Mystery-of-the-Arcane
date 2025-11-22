using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilheomsilPaper : MonoBehaviour
{
    private void OnMouseDown()
    {

        Debug.Log($"{gameObject.name} 클릭됨, Tag: {gameObject.tag}");

        if (gameObject.tag == "Math")
        {
            SceneManager.LoadScene("MathStartAfter");
        }
        else if (gameObject.tag == "Science")
        {
            Debug.Log("과학씬으로 이동");
            SceneManager.LoadScene("ScienceStartAfter");
        }
    }
}
