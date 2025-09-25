using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class DEStimer : MonoBehaviour
{

    public static DEStimer instance;
    [SerializeField] private TMPro.TMP_Text timeCounter;
    [SerializeField] private int StartTimeInSec = 0;
    private TimeSpan timePlaying;
    private bool timerGoing = false;
    private float elapsedTime;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = StartTimeInSec;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing && elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;
            yield return null;
        }
        print("stopped");
        SceneManager.LoadScene("Grotta");
    }
}
