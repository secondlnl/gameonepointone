using UnityEngine;
using TMPro;

public class PlayerPickups : MonoBehaviour
{
    [SerializeField] private TMP_Text cherryText;
    [SerializeField] private AudioClip PickupSound;
    [SerializeField] private GameObject CherryPart;
    public int CherryCount = 0;
    private AudioSource audi;
    void Start()
    {
        cherryText.text = CherryCount.ToString(); // CHANGED
        audi = GetComponent<AudioSource>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cherry"))
        {

            Destroy(other.gameObject);
            CherryCount++;
            cherryText.text = CherryCount.ToString(); //
            audi.pitch = Random.Range(0.8f, 1.2f);
            audi.PlayOneShot(PickupSound, 0.5f);
            Instantiate(CherryPart, other.transform.position, Quaternion.identity);

        }
    }
}
