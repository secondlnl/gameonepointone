using UnityEngine;

public class Snail : EnemyMovement
{
    private bool shelled = false;
    [SerializeField] private GameObject shell;
    [SerializeField] private Sprite Shelless;
    private Animator anim;
    protected override void Start()
    {
        base.Start();
        anim = gameObject.GetComponent<Animator>();

    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (shelled == true && other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            other.GetComponent<AudioSource>().PlayOneShot(HitSound, 0.5f);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            dead = true;
            Destroy(gameObject, 0.2f);
        }
        if (other.gameObject.CompareTag("Player") && shelled == false)
        {
            other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(other.GetComponent<Rigidbody2D>().linearVelocityX, 0);
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounciness));
            other.GetComponent<AudioSource>().PlayOneShot(HitSound, 0.5f);
            anim.SetTrigger("hit");
            print(base.MoveSpeed);
            base.MoveSpeed *= 2;
            Instantiate(shell, transform.position, Quaternion.identity);
            shelled = true;
            // Invoke("Shelled",1f);

        }
    }
    void Shelled()
    {
        shelled = true;
    }
}
