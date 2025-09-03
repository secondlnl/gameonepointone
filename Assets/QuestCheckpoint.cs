using UnityEngine;

public class QuestCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject dialoguebox, textnotfinished, textfinished;
    private Animator anim;
    [SerializeField] private int QuestGoal = 10;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) if (other.GetComponent<movement>().CherryCount >= QuestGoal)
            {
                dialoguebox.SetActive(true);
                textfinished.SetActive(true);
                anim.SetTrigger("Finished");
                // lvl CHANGE
            }
            else
            {
                dialoguebox.SetActive(true);
                textnotfinished.SetActive(true);
            }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguebox.SetActive(false);
            textfinished.SetActive(false);
            textnotfinished.SetActive(false);
        }
    }
}
