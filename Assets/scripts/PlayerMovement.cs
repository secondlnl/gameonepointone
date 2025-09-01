using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float Movementspeed = 1f;
    [SerializeField] private float JumpForce = 300f;
    private float horizontalValue = 0f;
    private float verticalValue = 0f;
    private Rigidbody2D rb;
    private SpriteRenderer srr;

    void Start()
    {
        srr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
        if (horizontalValue < 0) FlipSprite(true);
        if (horizontalValue < 0) FlipSprite(false);
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2((horizontalValue * Movementspeed * Time.deltaTime), rb.linearVelocityY);

    }
    private void FlipSprite(bool Direction)
    {
        srr.flipX = Direction;
    }
}
