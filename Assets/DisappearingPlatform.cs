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
        {
            part.enabled = false;
            CurrentTarget = Targetpos;
            anim.SetBool("animActive", false);
            transform.position = Vector2.MoveTowards(transform.position, CurrentTarget, MoveSpeed * Time.deltaTime);
        }
        else
        {
            part.enabled = true;
            CurrentTarget = Startpos;
            anim.SetBool("animActive", true);
            transform.position = Vector2.MoveTowards(transform.position, CurrentTarget, MoveSpeed * Time.deltaTime);
        }
    }
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
