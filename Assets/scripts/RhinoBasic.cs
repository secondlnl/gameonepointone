using UnityEngine;

public class RhinoBasic : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private float KnockbackForce = 400f;
    [SerializeField] private float Updraft = 180f;
    [SerializeField] private int DMGGiven = 1;
    [SerializeField] private AudioClip HitSound;
    [SerializeField] private Transform eyes;
    private SpriteRenderer sr;
    private bool dead = false;
    private bool canSeePlayer;
    private float rayDistance = 25f;




    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        
    }
}
