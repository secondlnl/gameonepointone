using UnityEngine;

public class Svamp : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3.0f;
    [SerializeField] private float rayRadius = 4.0f;
    [SerializeField] private Transform SvampEyes;
    [SerializeField] private LayerMask whatIsPlayer;

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
}
