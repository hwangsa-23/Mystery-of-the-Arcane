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

        // 🔥 Speed를 부드럽게 Lerp(보간)
        float targetSpeed = Mathf.Abs(inputVec.x) + Mathf.Abs(inputVec.y);
        float smoothSpeed = Mathf.Lerp(anim.GetFloat("Speed"), targetSpeed, 12f * Time.deltaTime);
        anim.SetFloat("Speed", smoothSpeed);

        anim.SetFloat("MoveX", inputVec.x);
        anim.SetFloat("MoveY", inputVec.y);

        // 🔥 방향 전환을 완화 (0.3 이상일 때만 반전)
        if (Mathf.Abs(inputVec.x) > 0.3f)
            spriter.flipX = inputVec.x < 0;
    }

    void FixedUpdate()
    {
        Vector2 nextPos = rigid.position + inputVec * speed * Time.fixedDeltaTime;

        nextPos.x = Mathf.Clamp(nextPos.x, minX, maxX);
        nextPos.y = Mathf.Clamp(nextPos.y, minY, maxY);

        rigid.MovePosition(nextPos);
    }
}
