using UnityEngine;

public class WallHack : MonoBehaviour
{
    private Animator anim;
    private bool HasPlayed;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && HasPlayed == false)
        {
            HasPlayed = true;
            anim.SetTrigger("move");
        }
    }
}
