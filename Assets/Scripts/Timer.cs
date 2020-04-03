using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        
    }
}
