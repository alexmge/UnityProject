using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selectlevels : MonoBehaviour
{

    public void Loadlevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Loadlevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Loadlevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Loadlevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Loadlevel5()
    {
        SceneManager.LoadScene("Level5");
    }
}
