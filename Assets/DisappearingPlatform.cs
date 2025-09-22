using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private bool Active = true;
    private bool Touched = false;
    private Vector3 Startpos;
    private Vector3 Targetpos;
    private Animator anim;
    private SpriteRenderer sr;
    private Vector3 CurrentTarget;
    private ParticleSystemRenderer part;
    [SerializeField] float MoveSpeed = 2f;
    [SerializeField] private Sprite sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        part = GetComponent<ParticleSystemRenderer>();
        Startpos = transform.position;
        Targetpos = Startpos + new Vector3(0, -2f);
        anim.SetBool("animActive", true);

    }
    void Update()
    {

        if (Active == false && Touched == true)
        // if (Vector2.Distance(transform.position,Startpos) < 0.1)
        {
            part.enabled = false;
            CurrentTarget = Targetpos;
            anim.SetBool("animActive", false);
            transform.position = Vector2.MoveTowards(transform.position, CurrentTarget, MoveSpeed * Time.deltaTime);
        }
        else
        // if (Vector2.Distance(transform.position,Targetpos) < 0.1)
        {
            part.enabled = true;
            CurrentTarget = Startpos;
            anim.SetBool("animActive", true);
            transform.position = Vector2.MoveTowards(transform.position, CurrentTarget, MoveSpeed * Time.deltaTime);
        }

        // if (Inactive == true)
        // {
        //     while (transform.position != Targetpos)
        //     { transform.position = Vector2.MoveTowards(transform.position, Targetpos, MoveSpeed * Time.deltaTime); }
        // }
        // if (Inactive == false)
        // {
        //     while (transform.position != Startpos)
        //     { transform.position = Vector2.MoveTowards(transform.position, Startpos, MoveSpeed * Time.deltaTime); }
        // }
    }
    // void Update()
    // {
    //     if (Active == true) return;
    //     if (anim.enabled == false)
    //     {
    //         Active = false;
    //         sr.sprite = sprite;
    //     }

    // }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Active == true)
            {
                print("COLL CALL:" + Active);
                Touched = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Active = false;
                Invoke("On", 10f);
            }
        }
    }
    private void On()
    {
        Touched = false;
        Active = true;
        GetComponent<BoxCollider2D>().enabled = true;

    }
}
