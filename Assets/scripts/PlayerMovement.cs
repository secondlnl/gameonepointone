using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    private float Movementspeed = 1f;
    private float horizontalValue = 0f;
    private float verticalValue = 0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        verticalValue = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2((horizontalValue * Movementspeed * Time.deltaTime), rb.linearVelocityY);

    }

}
