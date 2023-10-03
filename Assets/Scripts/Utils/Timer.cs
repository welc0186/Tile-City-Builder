using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    
    private float startSeconds;
    private float secondsLeft;

    public Timer(float seconds)
    {
        startSeconds = seconds;
        Reset();
    }

    public float TickDown(float seconds)
    {
        secondsLeft = secondsLeft - seconds;
        if(secondsLeft < 0)
        {
            Reset();
            return 0;
        }
        return secondsLeft;
    }

    public void Reset()
    {
        secondsLeft = startSeconds;
    }

}
