using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerFinish : MonoBehaviour
{

    public GameObject endScreen;
    public GameObject timer;
    public TMP_Text timedisplaying;

    public void Start()
    {
        timer = GameObject.Find("Timer");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered"); 
        if (other.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            endScreen.SetActive(true);
            string ttd = timer.GetComponent<Timer>().timer_text.text;
            timedisplaying.text = ttd;
            timer.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
