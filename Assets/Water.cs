using UnityEngine;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour
{
    private bool Move = false;
    private new Transform transform;
    private Vector2 newpos;
    [SerializeField] Transform Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Move)
        {
            newpos = Vector3.MoveTowards(transform.position, Target.position, 4f * Time.deltaTime);
            transform.position = newpos;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Move == false)
        {
            GetComponentInChildren<AreaEffector2D>().enabled = false;
            GetComponentInChildren<TilemapCollider2D>().usedByEffector = false;
            GetComponentInChildren<RespawnScript>().enabled = true;
            Move = true;
        }
    }
    public void Respawn()
    {
        Move = false;
        GetComponentInChildren<AreaEffector2D>().enabled = true;
        GetComponentInChildren<TilemapCollider2D>().usedByEffector = true;
        GetComponentInChildren<RespawnScript>().enabled = false;
        gameObject.transform.position = transform.position;
    }
}
