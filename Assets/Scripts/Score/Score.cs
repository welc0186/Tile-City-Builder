using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ScoreType {
    ADD,
    MULTIPLY,
    RESET
}

public class Score
{
    private int _amt;
    private ScoreType _type;
    public GameObject Source { get; private set; }

    public Score(int amt, ScoreType type, GameObject source = null)
    {
        _amt = amt;
        _type = type;
        if(source != null)
        {
            PointsPopupSpawner.Spawn(source, amt.ToString());
        }
    }

    public int ProcessScore(int inputScore)
    {
        switch(_type)
        {
            case ScoreType.ADD:
                return inputScore + _amt;
            case ScoreType.MULTIPLY:
                return inputScore * _amt;
            case ScoreType.RESET:
                return 0;
            default:
                return -1;
        }
    }

}
