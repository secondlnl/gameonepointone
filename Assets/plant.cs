using UnityEngine;

public class plant : MonoBehaviour
{
    [SerializeField] private bool fire;
    [SerializeField] private GameObject bullet;
    [SerializeField] private LayerMask Player;
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private Transform HitRay;
    private bool toggle = true;
    private bool LooP;
    private Animator anim;
    [SerializeField] private Vector3 offset = new Vector3(5f, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        while (HitScan() == true && LooP == false)
        {
            anim.SetBool("Angry", true);
            LooP = true;
            for (int i = 0; i <= 5; i++)
            {
                while (fire && toggle)
                {
                    toggle = false;
                    Instantiate(bullet, gameObject.transform.position + offset, Quaternion.identity);
                    Invoke("Timer", 0.5f);
                }
            }
            LooP = false;
            anim.SetBool("Angry", false);

        }
    }
    private void Timer()
    {
        toggle = true;
    }
    void Update()
    {

    }
    private bool HitScan()
    {
        RaycastHit2D Ray = Physics2D.Raycast(HitRay.position, Vector2.left, rayDistance, Player);
        Debug.DrawRay(HitRay.transform.position, Vector2.left, Color.red, 10);

        if (Ray.collider != null && Ray.collider.CompareTag("Player"))
        {
            return true;
        }
        else return false;

    }
}
