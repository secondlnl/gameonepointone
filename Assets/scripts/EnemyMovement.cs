using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = 2.0f;
    [SerializeField] protected float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 200f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] protected AudioClip HitSound;
    [SerializeField] private GameObject StonePart;
    protected SpriteRenderer sr;
    protected bool dead = false;
    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    protected virtual void FixedUpdate()
    {
        if (dead) return;
        transform.Translate(new Vector2(MoveSpeed, 0) * Time.deltaTime);
        if (MoveSpeed > 0) sr.flipX = true;
        if (MoveSpeed < 0) sr.flipX = false;
    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock")) MoveSpeed = -MoveSpeed;
        if (other.gameObject.CompareTag("Enemy")) MoveSpeed = -MoveSpeed;
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
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            other.GetComponent<AudioSource>().PlayOneShot(HitSound, 0.5f);
            GetComponent<Animator>().SetTrigger("hit");
            Instantiate(StonePart, transform.position, StonePart.transform.localRotation);

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            dead = true;
            if (GameObject.FindGameObjectWithTag("QUEST"))
            {
                GameObject.FindGameObjectWithTag("QUEST").GetComponent<newquest>().killed(1);
            }
            Destroy(gameObject, 0.6f);
        }
    }
}
