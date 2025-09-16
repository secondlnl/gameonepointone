using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int StartingHealth = 5;
    public int CurrentHealth = 0;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image fillcolor;
    [SerializeField] private Color greenHealth, RedHealth;
    [SerializeField] private Transform SpawnPosition;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = StartingHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Health"))
        {
            HealUp(other.gameObject);

        }
    }
    public void Respawn()
    {
        fillcolor.color = greenHealth;
        CurrentHealth = StartingHealth;
        UpdateHealthBar();
        transform.position = SpawnPosition.transform.position;
        rb.linearVelocity = Vector2.zero;
    }
    private void HealUp(GameObject healthPickUp)
    {
        /* 
        TUT 9 Fix
        Heal can't be picked up if it would heal too much  
        */
        int healthToRestore = healthPickUp.GetComponent<health>().HealPoints;
        if (CurrentHealth >= StartingHealth || (CurrentHealth + healthToRestore) > StartingHealth) return;
        else
        {
            CurrentHealth += healthToRestore;
            UpdateHealthBar();
            Destroy(healthPickUp);
            if (CurrentHealth >= StartingHealth) CurrentHealth = StartingHealth;
        }
    }
    public void UpdateHealthBar()
    {
        healthSlider.value = CurrentHealth;

        if (CurrentHealth >= 2) fillcolor.color = greenHealth; else fillcolor.color = RedHealth;

    }
}
