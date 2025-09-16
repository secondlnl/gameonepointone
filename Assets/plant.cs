using UnityEngine;

public class plant : MonoBehaviour
{
    [SerializeField] private bool fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask Player;
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private Transform HitRay;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private GameObject PlantPart;
    private bool dead = false;
    private bool toggle = true;
    private Animator anim;
    [SerializeField] private Vector3 offset = new Vector3(5f, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        anim.SetBool("Angry", HitScan());
    }
    void FixedUpdate()
    {
        if (dead) return;
        while (fire && toggle) // toggle HAS TO STAY to not crash
        {
            toggle = false;
            Instantiate(bullet, gameObject.transform.position + offset, Quaternion.identity);
            Invoke("Timer", 0.5f);

        }
    }

    private void Timer()
    {
        toggle = true;
    }
    private bool HitScan()
    {
        RaycastHit2D Ray = Physics2D.Raycast(HitRay.position, Vector2.left, rayDistance, Player);
        if (Ray.collider != null && Ray.collider.CompareTag("Player"))
        {
            return true;
        }
        else return false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
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
            GetComponent<Animator>().SetTrigger("hit");
            Instantiate(PlantPart, transform.position, PlantPart.transform.localRotation);

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            dead = true;
            Destroy(gameObject, 0.6f);
        }
    }
}
