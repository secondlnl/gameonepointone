using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float Movementspeed = 1f;
    [SerializeField] private float JumpForce = 300f;
    [SerializeField] private Transform LeftFoot, RightFoot;
    [SerializeField] private LayerMask Grounded;
    [SerializeField] private AudioClip[] JumpSounds;
    [SerializeField] private GameObject JumpPart;
    private float horizontalValue = 0f;
    private float rayDistance = 0.25f;
    // private bool DoubleJumping;
    // private bool Jumped;
    // private bool DoubleJumped;
    private Rigidbody2D rb;
    private SpriteRenderer srr;
    private Animator anim;
    private AudioSource audi;
    private PlayerDamage playerDamage;

    void Start()
    {
        srr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        playerDamage = GetComponent<PlayerDamage>();
    }

    void Update()
    {
        // print("cm: " + canMove);
        anim.SetBool("Grounded", CheckGround());
        //        print(CurrentHealth);
        horizontalValue = Input.GetAxis("Horizontal");
        if (horizontalValue < 0) FlipSprite(true);
        if (horizontalValue > 0) FlipSprite(false);

        if (Input.GetButtonDown("Jump"))
        {
            if (CheckGround() == true /*&& Jumped == false*/)
            {
                Jump();
                // Jumped = true;
            }
            // else if (Jumped == true && CheckGround() == false && DoubleJumped == false) DoubleJump();
        }

        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.linearVelocityX));
        anim.SetFloat("VerticalSpeed", rb.linearVelocityY);
        // anim.SetBool("doublejumping", DoubleJumping);

    }
    void FixedUpdate()
    {
        if (playerDamage.canMove == false) return;
        rb.linearVelocity = new Vector2((horizontalValue * Movementspeed * Time.deltaTime), rb.linearVelocityY);

    }

    private void FlipSprite(bool Direction)
    {
        srr.flipX = Direction;
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce));
        int RandomValue = Random.Range(0, JumpSounds.Length /*+ 1*/);
        //print(RandomValue);
        audi.PlayOneShot(JumpSounds[RandomValue], 0.5f);
        Instantiate(JumpPart, transform.position, JumpPart.transform.localRotation);
    }
    // private void DoubleJump()
    // {
    //     DoubleJumping = true;
    //     DoubleJumped = true;
    //     rb.AddForce(new Vector2(0, JumpForce));
    //     int RandomValue = Random.Range(0, JumpSounds.Length /*+ 1*/);
    //     print(RandomValue);
    //     audi.PlayOneShot(JumpSounds[RandomValue], 0.5f);
    //     Invoke("CanDoublejumpAgain", 1.4f);
    // }
    // private void CanDoublejumpAgain()
    // {
    //     DoubleJumping = false;
    //     DoubleJumped = false;
    //     Jumped = false;
    // }
    private bool CheckGround()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftFoot.position, Vector2.down, rayDistance, Grounded);
        RaycastHit2D RightHit = Physics2D.Raycast(RightFoot.position, Vector2.down, rayDistance, Grounded);

        if (leftHit.collider != null && leftHit.collider.CompareTag("Ground") || RightHit.collider != null && RightHit.collider.CompareTag("Ground"))
        {
            return true;
        }
        else return false;

    }

}
