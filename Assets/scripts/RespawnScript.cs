using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] public Transform respawnPoint;
    [SerializeField] public Transform player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            player.transform.position = respawnPoint.transform.position;
            other.GetComponent<PlayerHealth>().SpawnPosition = respawnPoint.transform;
        }
    }
}
