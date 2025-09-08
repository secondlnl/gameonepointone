using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    [SerializeField] private float Movementspeed = 1f;
    [SerializeField] private float JumpForce = 300f;
    [SerializeField] private Transform LeftFoot, RightFoot;
    [SerializeField] private LayerMask Grounded;
    [SerializeField] private Transform SpawnPosition;
    [SerializeField] private AudioClip[] JumpSounds;
    [SerializeField] private AudioClip[] HitSounds;

    [SerializeField] private AudioClip PickupSound;
    [SerializeField] private GameObject CherryPart, JumpPart;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillcolor;
    [SerializeField] private Color greenHealth, RedHealth;
    [SerializeField] private TMP_Text cherryText;

    private float horizontalValue = 0f;
    private float rayDistance = 0.25f;
    private bool canMove;
    // private bool DoubleJumping;
    // private bool Jumped;
    // private bool DoubleJumped;

    [SerializeField] private int StartingHealth = 5;
    private int CurrentHealth = 0;
    public int CherryCount = 0;
    private Rigidbody2D rb;
    private SpriteRenderer srr;
    private Animator anim;
    private AudioSource audi;

    void Start()
    {
        cherryText.text = CherryCount.ToString(); // CHANGED
        canMove = true;
        CurrentHealth = StartingHealth;
        srr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
    }

    void Update()
    {
        print("cm: " + canMove);
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
        if (canMove == false) return;
        rb.linearVelocity = new Vector2((horizontalValue * Movementspeed * Time.deltaTime), rb.linearVelocityY);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cherry"))
        {

            Destroy(other.gameObject);
            CherryCount++;
            cherryText.text = CherryCount.ToString(); //
            audi.pitch = Random.Range(0.8f, 1.2f);
            audi.PlayOneShot(PickupSound, 0.5f);
            Instantiate(CherryPart, other.transform.position, Quaternion.identity);

        }
        if (other.CompareTag("Health"))
        {
            HealUp(other.gameObject);

        }
    }
    private void FlipSprite(bool Direction)
    {
        srr.flipX = Direction;
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce));
        int RandomValue = Random.Range(0, JumpSounds.Length /*+ 1*/);
        print(RandomValue);
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
    public void TakeDMG(int DMGamount)
    {
        CurrentHealth -= DMGamount;
        UpdateHealthBar();

        if (CurrentHealth <= 0) Respawn();

    }
    public void TakeKnockback(float knockbackForce, float updraft)
    {
        anim.SetTrigger("hit");
        int RandomHit = Random.Range(0, HitSounds.Length /*+ 1*/);
        audi.pitch = Random.Range(0.8f, 1.2f);
        audi.PlayOneShot(HitSounds[RandomHit], 0.5f);
        canMove = false;
        rb.AddForce(new Vector2(knockbackForce, updraft));
        Invoke("CanMoveAgain", 0.25f);
    }
    private void CanMoveAgain()
    {
        anim.SetTrigger("hitdone");
        canMove = true;
    }
    private void Respawn()
    {
        fillcolor.color = greenHealth;
        CurrentHealth = StartingHealth;
        UpdateHealthBar();
        transform.position = SpawnPosition.transform.position;
        rb.linearVelocity = Vector2.zero;
    }
    private void HealUp(GameObject healthPickUp)
    {
        /* 
        TUT 9 Fix
        Heal can't be picked up if it would heal too much  
        */
        int healthToRestore = healthPickUp.GetComponent<health>().HealPoints;
        if (CurrentHealth >= StartingHealth || (CurrentHealth + healthToRestore) > StartingHealth) return;
        else
        {
            CurrentHealth += healthToRestore;
            UpdateHealthBar();
            Destroy(healthPickUp);
            if (CurrentHealth >= StartingHealth) CurrentHealth = StartingHealth;
        }
    }
    private void UpdateHealthBar()
    {
        healthSlider.value = CurrentHealth;

        if (CurrentHealth >= 2) fillcolor.color = greenHealth; else fillcolor.color = RedHealth;

    }
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
