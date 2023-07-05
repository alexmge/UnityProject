using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End_scipt : MonoBehaviour
{

    public GameObject ability1;
    public GameObject ability2;
    public void Start()
    {
        ability1.SetActive(false);
        ability2.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_menu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        // load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
