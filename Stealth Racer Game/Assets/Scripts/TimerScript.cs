using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static TimerScript timerRef;
    float timeElapsed = 0;
    bool isStopped = false;
    void Start()
    {
        timerRef = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped) return; //timer is stopped
        //update time elapsed
        timeElapsed += Time.deltaTime;
        //update timer text
        int msec = (int)(timeElapsed * 1000);
        int seconds = msec / 1000;
        int minutes = seconds / 60;
        seconds = seconds % 60;
        msec = msec % 1000;
        var text = transform.GetChild(0).GetComponent<Text>();
        text.text = minutes.ToString().PadLeft(2,'0') + ":" + seconds.ToString().PadLeft(2,'0') + ":" + msec.ToString().PadLeft(3,'0');
    }

    public void AddTimePenalty(float penaltySeconds)
    {
        timeElapsed += penaltySeconds;
    }

    public void EndGame()
    {
        isStopped = true;
    }
}
