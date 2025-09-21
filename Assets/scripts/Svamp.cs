using UnityEngine;

public class Svamp : MonoBehaviour
{
    [SerializeField] private float idleSpeed = 1.0f;
    [SerializeField] private float runSpeed = 3.0f;

    private SpriteRenderer sr;
    private bool dead = false;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (dead) return;
        transform.Translate(new Vector2(idleSpeed, 0) * Time.deltaTime);
        if (idleSpeed > 0) sr.flipX = true;
        if (idleSpeed < 0) sr.flipX = false;
    }
}
