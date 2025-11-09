using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassRoomObject : MonoBehaviour
{
    private void OnMouseDown()
    {

        Debug.Log($"{gameObject.name} Å¬¸¯µÊ, Tag: {gameObject.tag}");

        if (gameObject.tag == "Art")
        {
            SceneManager.LoadScene("ArtStartAfter");
        }
        else if (gameObject.tag == "English")
        {
            //Debug.Log("¿µ¾î¾ÀÀ¸·Î ÀÌµ¿");
            SceneManager.LoadScene("EnglishStartAfter");
        }
    }
}
