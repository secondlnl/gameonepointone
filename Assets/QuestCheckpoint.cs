using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject dialoguebox, textnotfinished, textfinished;
    [SerializeField] private int QuestGoal = 10;
    [SerializeField] private int NextLevel;
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
                other.GetComponent<TimerController>().EndTimer();
                // lvl CHANGE
                Invoke("LoadLevel", 2.0f);
                LoadingLevel = true;
            }
            else
            {
                dialoguebox.SetActive(true);
                textnotfinished.SetActive(true);
            }

    }
    private void LoadLevel() {
        PlayerPrefs.SetString("LevelTwo", "0");
        SceneManager.LoadScene(NextLevel);
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
