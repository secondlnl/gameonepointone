using UnityEngine;

public class pause : MonoBehaviour
{
    public bool Paused = false;
    [SerializeField] private GameObject Panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Panel.SetActive(Paused);
        if (Paused == true)
        {
            Time.timeScale = 0.0f;
        }
        else Time.timeScale = 1f;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
        }
    }
}
