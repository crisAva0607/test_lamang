using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 5;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    public TMP_Text LOSETEXT;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0)
            {
            timeRemaining -= Time.deltaTime;
            }
            else
            {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;
            LOSETEXT.gameObject.SetActive(true);
            Time.timeScale = 0; //Para magpause lahat sa game
            }
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }


        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float miliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }
}
