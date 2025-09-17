using UnityEngine;
using UnityEngine.Rendering;

public class SlimePebbles : MonoBehaviour
{
    [SerializeField] private float KnockbackForce = 200f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private Sprite[] Pebbles;

    void Start()
    {
        int i = Random.Range(0, 4);
        print(i);
        GetComponent<SpriteRenderer>().sprite = Pebbles[i];
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerDamage>().TakeDMG(DMGGiven);

            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(KnockbackForce, Updraft);
            }
            else { other.gameObject.GetComponent<PlayerDamage>().TakeKnockback(-KnockbackForce, Updraft); }
        }
    }
}
