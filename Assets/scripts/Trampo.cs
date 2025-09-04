using UnityEditor.Callbacks;
using UnityEngine;

public class Trampo : MonoBehaviour
{
    [SerializeField] private float JumpForce = 200f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(0, JumpForce));
            GetComponent<Animator>().SetTrigger("jump");
        }
    }
}
