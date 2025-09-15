using UnityEngine;
using UnityEngine.SceneManagement;

public class castletrigger : MonoBehaviour
{
    [SerializeField] private Camera Cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {

            other.gameObject.GetComponent<movement>().enabled = false;
            other.gameObject.GetComponent<Animator>().Play("PinkRun", -1);
            other.gameObject.GetComponent<Animator>().SetFloat("MoveSpeed", 0.2f);
            Invoke("LoadLevel", 3.21f);
            
        }
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
