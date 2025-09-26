using UnityEngine;

public class WoodenGate : MonoBehaviour
{
    private Animator anim;
    private bool hasPlayed;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hasPlayed == false)
            //Quest complete
        {
            hasPlayed = true;
            anim.SetTrigger("Lower");
        }

    }
}
