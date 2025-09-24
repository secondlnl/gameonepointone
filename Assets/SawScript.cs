using UnityEngine;

public class SawScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] sawCheckpoints;
    [SerializeField] private float upwardForce = 300f, forwardForce = 200f;
    
    private int currentCheckpointIndex = 0;
    
    
    private void Update()
    {
        if (sawCheckpoints.Length == 0) return;

        Transform targetCheckpoint = sawCheckpoints[currentCheckpointIndex];
        Vector3 direction = (targetCheckpoint.position - transform.position).normalized;
        transform.position += direction * (speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetCheckpoint.position) < 0.1f)
        {
            currentCheckpointIndex = (currentCheckpointIndex + 1) % sawCheckpoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerDamage>().TakeDMG(1);
        if (other.transform.position.x < transform.position.x)
            other.GetComponent<PlayerDamage>().TakeKnockback(-forwardForce, upwardForce);
        else
            other.GetComponent<PlayerDamage>().TakeKnockback(forwardForce, upwardForce);
        
    }
    
}
