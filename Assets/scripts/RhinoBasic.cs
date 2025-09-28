using UnityEngine;

public class RhinoBasic : MonoBehaviour
{
    [SerializeField] private float chargeSpeed = 10.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform eyes;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private Transform target1, target2;
    [SerializeField] private float rayRadius = 10f;

    private SpriteRenderer sr;
    private bool dead = false;
    private bool canSeePlayer;
    private Transform currentTarget;


    void Start()
    {
        currentTarget = target1;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CanSeePlayer();
    }

    private void FixedUpdate()
    {
        if (dead) return;

        if (transform.position == target1.position)
        {
            currentTarget = target2;
        }
        if (transform.position == target2.position)
        {
            currentTarget = target1;
        }
        if (chargeSpeed > 0) sr.flipX = false;
        if (chargeSpeed < 0) sr.flipX = true;

        if (canSeePlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, chargeSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock"))
        {
            GetComponent<Animator>().SetTrigger("WallStun");
            Invoke("WallStun", 3.0f);
            dead = true;
        }
        if (other.gameObject.CompareTag("Enemy")) chargeSpeed = -chargeSpeed;
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerDamage>().TakeDMG(DMGGiven);

            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(KnockbackForce, Updraft);
            }
            else { other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(-KnockbackForce, Updraft); }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            other.GetComponent<AudioSource>().PlayOneShot(HitSound, 0.5f);
            GetComponent<Animator>().SetTrigger("Hit");

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            if (GameObject.FindGameObjectWithTag("QUEST"))
            {
                GameObject.FindGameObjectWithTag("QUEST").GetComponent<newquest>().killed(1);
            }
            dead = true;
            Destroy(gameObject, 0.6f);
        }
    }

    private void CanSeePlayer()
    {
        RaycastHit2D playerSeen = Physics2D.CircleCast(eyes.position, rayRadius, Vector2.one, rayRadius, whatIsPlayer);

        if (playerSeen.collider != null && playerSeen.collider.CompareTag("Player"))
        {
            canSeePlayer = true;
            GetComponent<Animator>().SetBool("CanSeePlayer", true);
        }
        else
        {
            canSeePlayer = false;
            GetComponent<Animator>().SetBool("CanSeePlayer", false);
        }
    }

    void WallStun()
    {
        {
            dead = false;
            chargeSpeed = -chargeSpeed;
        }
    }
}
