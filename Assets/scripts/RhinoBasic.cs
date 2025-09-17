using UnityEngine;

public class RhinoBasic : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform eyes;
    [SerializeField] private AudioClip HitSound;
    private SpriteRenderer sr;
    private bool dead = false;
    private bool canSeePlayer;
    private float rayDistance = 25f;




    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        CanSeePlayer();
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

    private bool CanSeePlayer()
    {
        RaycastHit2D playerSeen = Physics2D.Raycast(eyes.position, Vector2.left, rayDistance, whatIsPlayer);

        if(playerSeen.collider != null && playerSeen.collider.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
