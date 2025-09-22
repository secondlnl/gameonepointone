using UnityEngine;

public class Svamp : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private float rayRadius = 4.0f;
    [SerializeField] private Transform SvampEyes;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject svampCloud;

    private SpriteRenderer sr;
    private bool dead = false;
    private bool canSeePlayer;




    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CanSeePlayer();
    }

    private void FixedUpdate()
    {
        if (dead) return;

        if (canSeePlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }

        this.sr.flipX = target.transform.position.x > this.transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dead = true;
            GetComponent<Animator>().SetTrigger("Grow");
            Invoke("Cloud", 1.0f);
            Destroy(gameObject, 1.0f);
        }
    }

    private void CanSeePlayer()
    {
        RaycastHit2D playerSeen = Physics2D.CircleCast(SvampEyes.position, rayRadius, Vector2.one, rayRadius, whatIsPlayer);

        if (playerSeen.collider != null && playerSeen.collider.CompareTag("Player"))
        {
            Debug.Log("Player Detected!");
            canSeePlayer = true;
            GetComponent<Animator>().SetBool("CanSeePlayer", true);
        }
        else
        {
            canSeePlayer = false;
            GetComponent<Animator>().SetBool("CanSeePlayer", false);
        }
    }

    private void Cloud()
    {
        //Explosion particle effect trigger
        Instantiate(svampCloud, SvampEyes.transform.position, Quaternion.identity);
    }
}
