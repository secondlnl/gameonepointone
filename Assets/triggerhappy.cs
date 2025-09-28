using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerhappy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
            other.gameObject.GetComponent<Animator>().Play("PinkRun");
            other.gameObject.GetComponent<Animator>().SetFloat("MoveSpeed", 0.2f);
            other.gameObject.GetComponent<Animator>().SetFloat("VerticalSpeed", 0f);
            other.gameObject.transform.position += new Vector3(0.05f, 0f);
            Invoke("LoadLvl", 2.0f);
        }

    }
    private void LoadLvl()
    {
        SceneManager.LoadScene(2);
    }
}
