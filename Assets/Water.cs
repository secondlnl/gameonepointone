using UnityEngine;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour
{
    private bool Move = false;

    private Vector2 newpos;
    [SerializeField] Transform Target;

    // Update is called once per frame
    void FixedUpdate()
    {
        print("fu: " + gameObject.transform.position);

        if (Move)
        {
            newpos = Vector3.MoveTowards(transform.position, Target.position, 3f * Time.deltaTime);
            transform.position = newpos;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Move == false)
        {
            print("COLL");
            GetComponentInChildren<AreaEffector2D>().enabled = false;
            GetComponentInChildren<TilemapCollider2D>().usedByEffector = false;
            GetComponentInChildren<TilemapCollider2D>().isTrigger = true;
            GetComponentInChildren<RespawnScript>().enabled = true;
            GetComponentInChildren<Waterrespawn>().enabled = true;
            GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>().pitch = 2;
            Move = true;
        }
    }
    public void Respawn()
    {
        if (Move == true)
        {
            transform.position = new Vector3(0.06f, -0.01f, -0.14f);
            Move = false;
            GetComponentInChildren<AreaEffector2D>().enabled = true;
            GetComponentInChildren<TilemapCollider2D>().usedByEffector = true;
            GetComponentInChildren<TilemapCollider2D>().isTrigger = false;
            // GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().CurrentHealth = 5;
            GetComponentInChildren<RespawnScript>().enabled = false;
            transform.position = new Vector3(0.06f, -0.01f, -0.14f);
            print(": " + gameObject.transform.position);
            GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>().pitch = 1;
            GetComponentInChildren<Waterrespawn>().enabled = false;
            transform.position = new Vector3(0.06f, -0.01f, -0.14f);


        }
        print("after: " + gameObject.transform.position);

    }
}
