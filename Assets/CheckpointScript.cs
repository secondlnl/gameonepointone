using System;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private RespawnScript respawn;


    private void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            respawn.respawnPoint = gameObject.transform;
            gameObject.SetActive(false); // makes it so you can't backtrack checkpoints
        }
    }
}
