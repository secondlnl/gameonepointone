using UnityEngine;

public class timertrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<DEStimer>().EndTimer();
        }
    }
}
