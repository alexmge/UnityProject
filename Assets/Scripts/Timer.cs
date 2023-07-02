using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeRemaining = 0;
    public bool timerIsRunning = true;
    public TMP_Text timer_text;


    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if(timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeToDisplay += 1;
    }
}
