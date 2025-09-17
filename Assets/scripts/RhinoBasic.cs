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
