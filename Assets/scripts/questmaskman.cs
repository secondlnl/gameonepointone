using UnityEngine;

public class questmaskman : MonoBehaviour
{
    [SerializeField] private GameObject textPopUp;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) textPopUp.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) if (other.CompareTag("Player")) textPopUp.SetActive(false);
    }
}
