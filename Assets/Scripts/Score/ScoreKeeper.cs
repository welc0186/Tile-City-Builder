using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public int Score { get; private set; }

    void Start()
    {
        Events.onScoreEvent.Subscribe(OnScoreEvent);
    }

    void OnDestroy()
    {
        Events.onScoreEvent.Unsubscribe(OnScoreEvent);
    }

    private void OnScoreEvent(Score score)
    {
        Score = score.ProcessScore(Score);
        Debug.Log("Score updated to " + Score);
    }


}
