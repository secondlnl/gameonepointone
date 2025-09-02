using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] private Transform SpawnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = SpawnPosition.transform.position;
            other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
