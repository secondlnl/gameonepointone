using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject dialoguebox, textnotfinished, textfinished;
    [SerializeField] private int QuestGoal = 10;
    [SerializeField] private int NextLevel;
    [SerializeField] private GameObject trigger;
    private Animator anim;
    private bool LoadingLevel = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) if (other.GetComponent<PlayerPickups>().CherryCount >= QuestGoal)
            {
                dialoguebox.SetActive(true);
                textfinished.SetActive(true);
                anim.SetTrigger("Finished");
                Invoke("Trigger", 2.0f);
            }
            else
            {
                dialoguebox.SetActive(true);
                textnotfinished.SetActive(true);
            }

    }
    private void Trigger()
    {
        trigger.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && LoadingLevel == false)
        {
            dialoguebox.SetActive(false);
            textfinished.SetActive(false);
            textnotfinished.SetActive(false);
        }
    }
}
