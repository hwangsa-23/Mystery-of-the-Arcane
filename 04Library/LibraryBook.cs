using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryBook : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (ClueSpawner.IsClueOpen) return;

        //Debug.Log($"{gameObject.name} Å¬¸¯µÊ, Tag: {gameObject.tag}");

        if (gameObject.tag == "History")
        {
            SceneManager.LoadScene("HistoryStartAfter");
        }
        else if (gameObject.tag == "Korean")
        {
            SceneManager.LoadScene("KoreanStartAfter");
        }
    }
}
