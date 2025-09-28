using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating("SpawnCloud", 0f, spawnInterval);
    }

    void SpawnCloud()
    {
        if (spawnPoints.Length == 0)
        {
            return;
        }
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        cloudPrefab.transform.localScale = Random.Range(0.5f, 1f) * Vector3.one;
        Instantiate(cloudPrefab, spawnPoint.position, Quaternion.identity);
    }
    
}