using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    // Text attribute
    public TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

        StartCoroutine(CounterStart());
    }

    IEnumerator CounterStart()
    {
        text.text = "3";
        yield return new WaitForSecondsRealtime(1);
        text.text = "2";
        yield return new WaitForSecondsRealtime(1);
        text.text = "1";
        yield return new WaitForSecondsRealtime(1);
        text.text = "GO!";
        Time.timeScale = 1f;  
        yield return new WaitForSecondsRealtime(1);
        text.text = "";

        gameObject.SetActive(false);
    }
}
