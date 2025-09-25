using UnityEngine;

public class Waterrespawn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("water").GetComponent<Water>().Respawn();
        }
    }
}
