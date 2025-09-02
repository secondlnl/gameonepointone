using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float Movementspeed = 1f;
    [SerializeField] private float JumpForce = 300f;
    [SerializeField] private Transform LeftFoot, RightFoot;
    [SerializeField] private LayerMask Grounded;
    private float horizontalValue = 0f;
    private float rayDistance = 0.25f;
    private bool OnGround;
    private Rigidbody2D rb;
    private SpriteRenderer srr;
    private Animator anim;

    void Start()
    {
        srr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        if (horizontalValue < 0) FlipSprite(true);
        if (horizontalValue > 0) FlipSprite(false);

        if (Input.GetButtonDown("Jump") && CheckGround() == true) Jump();

        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.linearVelocityX));
        anim.SetFloat("VerticalSpeed", rb.linearVelocityY);
        anim.SetBool("Grounded", CheckGround());
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2((horizontalValue * Movementspeed * Time.deltaTime), rb.linearVelocityY);

    }
    private void FlipSprite(bool Direction)
    {
        srr.flipX = Direction;
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce));
    }
    private bool CheckGround()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftFoot.position, Vector2.down, rayDistance, Grounded);
        RaycastHit2D RightHit = Physics2D.Raycast(RightFoot.position, Vector2.down, rayDistance, Grounded);
        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || RightHit.collider != null && RightHit.collider.CompareTag("Ground")) return true; else return false;
        
    }
}
