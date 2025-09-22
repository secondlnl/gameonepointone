using System.Collections.Generic;
using UnityEngine;

public class SvampExplosion : MonoBehaviour
{
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        Destroy(gameObject, 1.0f);
    }

    private void OnParticleCollision(GameObject other)
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
