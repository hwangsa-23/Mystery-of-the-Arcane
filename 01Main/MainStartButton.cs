using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStartButton : MonoBehaviour
{
    
    public void ClickedStartButton()
    {
        Debug.Log("버튼 클릭됨");
        SceneManager.LoadScene("02MainSelectEP");
    }
}
