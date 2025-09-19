using UnityEngine;

public class RhinoBasic : MonoBehaviour
{
    [SerializeField] private float chargeSpeed = 5.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform eyes;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private Transform target1, target2;
    
    private SpriteRenderer sr;
    private bool dead = false;
    private bool canSeePlayer;
    private float rayDistance = 25f;
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
        if (transform.position == target1.position)
        {
            currentTarget = target2;
        }
        if (transform.position == target2.position)
        {
            currentTarget = target1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock")) chargeSpeed = -chargeSpeed;
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

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            dead = true;
            Destroy(gameObject, 0.6f);
        }
    }

    private void CanSeePlayer()
    {
        RaycastHit2D playerSeen = Physics2D.Raycast(eyes.position, Vector2.left, rayDistance, whatIsPlayer);

        if(playerSeen.collider != null && playerSeen.collider.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
        }
    }
}
