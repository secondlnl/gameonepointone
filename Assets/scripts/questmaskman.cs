using System;
using UnityEngine;

public class questmaskman : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    private bool textPopUpActive = true;
    
    private float fadeDuration = 0.5f;
    private SpriteRenderer spriteRenderer;
    private float fadeTimer;
    private bool isFading = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (isFading)
        {
            fadeTimer -= Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);

            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;

            if (fadeTimer <= 0f)
            {
                gameObject.SetActive(false);
                isFading = false;
            }
        }
    }
    
    public void StartFade()
    {
        fadeTimer = fadeDuration;
        isFading = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && textPopUpActive) textPopUp.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) if (other.CompareTag("Player")) textPopUp.SetActive(false);
        textPopUpActive = false;
        StartFade();
    }
}
