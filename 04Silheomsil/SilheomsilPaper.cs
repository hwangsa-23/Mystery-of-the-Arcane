using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SilheomsilPaper : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ClueSpawner.IsClueOpen) return;

        //Debug.Log($"{gameObject.name} ≈¨∏Øµ , Tag: {gameObject.tag}");

        if (gameObject.tag == "Math")
        {
            SceneManager.LoadScene("MathStartAfter");
        }
        else if (gameObject.tag == "Science")
        {
            Debug.Log("∞˙«–æ¿¿∏∑Œ ¿Ãµø");
            SceneManager.LoadScene("ScienceStartAfter");
        }
    }
}
