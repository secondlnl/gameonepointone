using UnityEngine;

public class Rockhead : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystemRenderer part;
    private AudioSource audi;
    private Animator anim;
    private bool Moving = false;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 200f;
    [SerializeField] private int DMGGiven = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        part = GetComponent<ParticleSystemRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audi = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        part.enabled = false;
        anim.enabled = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && Moving == true)
        {
            Moving = false; part.enabled = true; audi.PlayOneShot(HitSound, 0.5f); anim.enabled = true;
        }
        if (other.gameObject.CompareTag("Player") && Moving == true)
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
        if (other.CompareTag("Player") && rb.bodyType == RigidbodyType2D.Static)
        {
            Moving = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
