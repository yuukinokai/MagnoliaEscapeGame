using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public float timeStart;
    public Text textBox;

    float seconds = 0;
    int minutes = 0;
    int hours = 0;

    // Use this for initialization
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        seconds = timeStart;
        minutes = (int) seconds / 60;
        hours = minutes / 60;
        seconds = seconds % 60;
        minutes = minutes % 60;
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;

        float newS = timeStart % 60;

        if (newS < seconds)
        {
            minutes++; 
        }
        seconds = newS;
        if(minutes >= 60)
        {
            hours++;
            minutes = 0;
        }

        string timeString = hours.ToString() + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        textBox.text = timeString;

    }
}
