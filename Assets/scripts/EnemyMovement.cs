using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector2(MoveSpeed, 0) * Time.deltaTime);

        if (MoveSpeed > 0) sr.flipX = true;
        if (MoveSpeed < 0) sr.flipX = false;

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock")) MoveSpeed = -MoveSpeed;
        if (other.gameObject.CompareTag("Enemy")) MoveSpeed = -MoveSpeed;
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<movement>().TakeDMG(DMGGiven);

            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<movement>().TakeKnockback(KnockbackForce, Updraft);
            }
            else { other.gameObject.GetComponent<movement>().TakeKnockback(-KnockbackForce, Updraft); }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
        Destroy(gameObject);
        }
    }
}
