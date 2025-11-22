using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;

    Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    float minX = -35.3f;
    float maxX = 38f;
    float minY = -2.5f;
    float maxY = -1f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", inputVec.x);
        anim.SetFloat("MoveY", inputVec.y);
        anim.SetFloat("Speed", inputVec.sqrMagnitude);

        if (inputVec.x > 0) spriter.flipX = true;
        else if (inputVec.x < 0) spriter.flipX = false;
    }

    void FixedUpdate()
    {
        Vector2 nextPos = rigid.position + inputVec * speed * Time.fixedDeltaTime;

        nextPos.x = Mathf.Clamp(nextPos.x, minX, maxX);
        nextPos.y = Mathf.Clamp(nextPos.y, minY, maxY);

        rigid.MovePosition(nextPos);
    }
}
