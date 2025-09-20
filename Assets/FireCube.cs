using UnityEngine;

public class FireCube : MonoBehaviour
{
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 200f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private Sprite off;
    private Animator anim;
    private SpriteRenderer sr;
    public bool IsFire = false;
    private bool Invornible = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Off()
    {
        anim.enabled = false;
        sr.sprite = off;
        IsFire = false;
    }
    private void On()
    {
        anim.enabled = true;
        Invoke("Fire", 0.2f);
    }
    private void Fire()
    {
        IsFire = true;
    }
    private void HitPlayer(Collider2D other)
    {
        if (Invornible) return;
        other.gameObject.GetComponent<PlayerDamage>().TakeDMG(DMGGiven);
        Invornible = true;
        if (other.transform.position.x > transform.position.x)
        {
            other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(KnockbackForce, Updraft);
        }
        else { other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(-KnockbackForce, Updraft); }
        Invoke("NotInvornible", 0.2f);
    }
    private void NotInvornible()
    {
        Invornible = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsFire == true)
            {
                HitPlayer(other);
                Off();
            }
            else if (IsFire == false)
            {
                On();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsFire == false)
            {
                On();
            }
            if (IsFire == true)
            {
                HitPlayer(other);
                anim.enabled = false;
                IsFire = false;
                sr.sprite = off;
            }

        }
    }
}
