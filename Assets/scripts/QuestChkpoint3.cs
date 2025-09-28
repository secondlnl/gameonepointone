using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChkpoint3 : MonoBehaviour
{
    [SerializeField] private GameObject dialoguebox, textnotfinished, textfinished;
    [SerializeField] private int NextLevel;
    [SerializeField] private GameObject WoodenGate;
    [SerializeField] private GameObject Trigger;
    private Animator anim;
    private bool LoadingLevel = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) if (other.GetComponent<PlayerPickups>().CherryCount >= 15
        && GameObject.FindGameObjectWithTag("QUEST").GetComponent<newquest>().Finished == true)
            {
                dialoguebox.SetActive(true);
                textfinished.SetActive(true);
                anim.SetTrigger("Finished");
                WoodenGate.GetComponent<Animator>().SetTrigger("Lower");
                // lvl CHANGE
                LoadingLevel = true;
                PlayerPrefs.SetString("LevelThree", "0");
                Trigger.SetActive(true);
            }
            else
            {
                dialoguebox.SetActive(true);
                textnotfinished.SetActive(true);
            }

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
