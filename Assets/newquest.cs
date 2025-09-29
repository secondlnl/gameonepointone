using System;
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
    public bool Finished = false;
    private SpriteRenderer giversr;
    [SerializeField] private int killedcount = 0;
    // private GameObject[] ba;
    void OnTriggerEnter2D(Collider2D other)
    {
        // ba = GameObject.FindGameObjectsWithTag("Enemy");
        // print(Mathf.Abs(GameObject.FindGameObjectsWithTag("Enemy").Length - EnemyGoal));
        // print("len:" + GameObject.FindGameObjectsWithTag("Enemy").Length);
        if (other.CompareTag("Player"))
        {
            Textpopup.SetActive(true);
            EnemyKillUI.SetActive(true);
        }
        if (other.CompareTag("Player")
        && EnemyKillUI.activeInHierarchy == true
        && other.GetComponent<PlayerPickups>().CherryCount >= CherryGoal
        && killedcount >= EnemyGoal)
        {
            Finished = true;
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
    void Start()
    {
        giversr = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x > giversr.gameObject.transform.position.x)
        {
            giversr.flipX = false;
        }
        else giversr.flipX = true;
    }
}
