using UnityEngine;

public class WoodenGate : MonoBehaviour
{
    private Animator anim;
    private bool hasPlayed = false;

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
            Invoke("LowerGate", 2.0f);
        }

    }

    private void LowerGate()
    {
        if (hasPlayed)
        {
            anim.SetTrigger("Lower");
        }
    }
}
