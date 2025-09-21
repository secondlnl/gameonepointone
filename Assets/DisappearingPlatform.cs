using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private bool Inactive = false;
    private Vector3 Startpos;
    private Vector3 Targetpos;
    private Animator anim;
    private SpriteRenderer sr;
    [SerializeField] float MoveSpeed = 2f;
    [SerializeField] private Sprite sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Startpos = transform.position;
        Targetpos = Startpos + new Vector3(0, -2f);
    }
    void FixedUpdate()
    {
        if (Inactive == true)
        {
            while (transform.position != Targetpos)
            { transform.position = Vector2.MoveTowards(transform.position, Targetpos, MoveSpeed * Time.deltaTime); }
        }
        if (Inactive == false)
        {
            while (transform.position != Startpos)
            { transform.position = Vector2.MoveTowards(transform.position, Startpos, MoveSpeed * Time.deltaTime); }
        }
    }
    void Update()
    {
        if (Inactive == true) return;
        if (anim.enabled == false)
        {
            Inactive = true;
            sr.sprite = sprite;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("COLL CALL:" + Inactive);
            if (Inactive == false)
            {
                Off();
                Inactive = true;

                Invoke("On", 10f);
            }
        }
    }
    private void Off()
    {
        Inactive = true;
        GetComponent<BoxCollider2D>().enabled = false;
        anim.enabled = false;
        sr.sprite = sprite;

    }
    private void On()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        Inactive = false;
        anim.enabled = true;

    }
}
