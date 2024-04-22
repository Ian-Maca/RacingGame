using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public CarController car;
    public Text timerText;
    public Text pbText; 

    private void Update()
    {
        float runTime = car._current_time;
        float pbTime = car._personal_best;

        if (pbTime >= 999999f)
        {
            pbText.text = "Personal Best: None";
        }
        else
        {
            pbText.text = "Personal Best: " + FormatTimer(pbTime);
        }
        
        timerText.text = FormatTimer(runTime);
        
    }

    private string FormatTimer(float timeInSeconds) {
        var minutes = Mathf.FloorToInt(timeInSeconds / 60);
        var seconds = Mathf.FloorToInt(timeInSeconds % 60);
        var milliseconds = Mathf.FloorToInt((timeInSeconds * 1000) % 1000); 

        var formattedTime = $"{minutes:00}:{seconds:00}:{milliseconds:000}"; 
        return formattedTime;
    }



}
