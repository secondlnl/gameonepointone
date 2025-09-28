using System.Collections;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public float minFloatDistance = 0.2f;
    public float maxFloatDistance = 0.5f;

    public float minFrequency = 0.5f;
    public float maxFrequency = 1.5f;

    private float floatDistance;
    private float frequency;
    private float phaseOffset;

    private float fadeDuration = 2.0f;
    private SpriteRenderer sr;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;

        sr = GetComponent<SpriteRenderer>();
         //sr.sortingOrder = Random.Range(-1, 2);

        // Randomize sine wave parameters
        floatDistance = Random.Range(minFloatDistance, maxFloatDistance);
        frequency = Random.Range(minFrequency, maxFrequency);
        phaseOffset = Random.Range(0f, Mathf.PI * 2f); // Full sine wave phase offset

        StartCoroutine(FadeInSprite());
    }

    IEnumerator FadeInSprite()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);

            Color color = sr.color;
            color.a = alpha;
            sr.color = color;

            yield return null;
        }
    }

    void Update()
    {
        // Sine wave motion with random frequency and phase
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency + phaseOffset) * floatDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Move cloud to the left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}