using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newquest : MonoBehaviour
{
    [Header("Quest Settings")]
    [SerializeField] private int CherryGoal = 1;
    [SerializeField] private int EnemyGoal = 1;
    [Header("")]
    [SerializeField] private GameObject Textpopup;
    [SerializeField] private GameObject EnemyKillUI;
    private int killedcount = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        print(Mathf.Abs(GameObject.FindGameObjectsWithTag("Enemy").Length - EnemyGoal));
        print(":" + GameObject.FindGameObjectsWithTag("Enemy").Length);
        if (other.CompareTag("Player"))
        {
            Textpopup.SetActive(true);
            EnemyKillUI.SetActive(true);
        }
        if (other.CompareTag("Player") && EnemyKillUI.activeInHierarchy == true && other.GetComponent<PlayerPickups>().CherryCount >= CherryGoal && EnemyGoal == Mathf.Abs(GameObject.FindGameObjectsWithTag("Enemy").Length - EnemyGoal))
        {
            PlayerPrefs.SetString("LevelThree", "0");
            SceneManager.LoadScene(0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Textpopup.SetActive(false);

    }
    public void killed(int amount)
    {
        killedcount += amount;
        EnemyKillUI.GetComponentInChildren<TMP_Text>().text = killedcount.ToString();
    }
}
