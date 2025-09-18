using UnityEngine;

public class SnailShell : EnemyMovement
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        base.MoveSpeed *= 2.5f;
        anim = gameObject.GetComponent<Animator>();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBlock"))
        {
            anim.SetTrigger("Wallhit");

        }

        base.OnCollisionEnter2D(other);
    }
}
