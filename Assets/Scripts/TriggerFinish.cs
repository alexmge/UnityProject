using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinish : MonoBehaviour
{

    public GameObject endScreen;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered"); 
        if (other.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            endScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
