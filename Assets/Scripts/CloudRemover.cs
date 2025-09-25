using System;
using UnityEngine;

public class CloudRemover : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            Destroy(other.gameObject);
        }
    }
}
