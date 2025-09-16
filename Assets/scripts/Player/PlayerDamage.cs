using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private AudioClip[] HitSounds;

    private AudioSource audi;
    private Animator anim;
    private Rigidbody2D rb;
    public bool canMove;
    private PlayerHealth playerHealth;

    void Start()
    {
        audi = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        canMove = true;

    }
    public void TakeDMG(int DMGamount)
    {
        playerHealth.CurrentHealth -= DMGamount;
        playerHealth.UpdateHealthBar();

        if (playerHealth.CurrentHealth <= 0) playerHealth.Respawn();

    }
    public void TakeKnockback(float knockbackForce, float updraft)
    {
        anim.SetTrigger("hit");
        int RandomHit = Random.Range(0, HitSounds.Length /*+ 1*/);
        audi.pitch = Random.Range(0.8f, 1.2f);
        audi.PlayOneShot(HitSounds[RandomHit], 0.5f);
        canMove = false;
        rb.AddForce(new Vector2(knockbackForce, updraft));
        Invoke("CanMoveAgain", 0.25f);
    }
    private void CanMoveAgain()
    {
        anim.SetTrigger("hitdone");
        canMove = true;
    }
}
