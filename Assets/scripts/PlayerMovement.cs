using UnityEngine;

public class movement : MonoBehaviour
{
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
        rb.velocity = new Vector2(horizontalValue, verticalValue);

    }

}
