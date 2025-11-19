using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassRoomDoor : MonoBehaviour
{
    public void ClickedClassRoom()
    {
        SceneManager.LoadScene("04ClassRoom");
    }
}
