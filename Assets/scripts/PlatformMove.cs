using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private Transform TargetEnd, TargetStart;
    [SerializeField] private float moveSpeed = 2.0f;

    private Transform CurrentTarget;
    void Start()
    {
        CurrentTarget = TargetStart;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToTarget = Vector2.Distance(transform.position, CurrentTarget.position);

        if (distanceToTarget < 0.1f)
        {
            if (CurrentTarget == TargetStart)
            {
                CurrentTarget = TargetEnd;
            }
            else
            {
                CurrentTarget = TargetStart;
            }
        }
            
        
        transform.position = Vector2.MoveTowards(transform.position, CurrentTarget.position, moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y) other.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) other.transform.SetParent(null);
    }
}
