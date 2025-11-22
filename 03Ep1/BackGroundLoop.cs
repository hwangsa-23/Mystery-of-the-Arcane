using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    float width;

    void Awake(){
        BoxCollider2D BackGroundCollider = GetComponent<BoxCollider2D>();
        width = BackGroundCollider.size.x;
    }

    void Start(){

    }

    void Update(){
        if(transform.position.x <= -width){
            Reposition();
        }
    }

    void Reposition(){
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}
