using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class Events
{
    // ** Audio **
    public static readonly CustomEvent<AudioRequest> onAudioRequested = new CustomEvent<AudioRequest>();
    
    // ** Gameplay **

    // GameObject should be placed tile
    public static readonly CustomEvent<GameObject> onTilePlaced = new CustomEvent<GameObject>();

    public static readonly CustomEvent<Score> onScoreEvent = new CustomEvent<Score>();
}

public class CustomEvent
{
    private event Action _event;

    public void Invoke()
    {
        _event?.Invoke();
    }

    public void Subscribe(Action listener)
    {
        _event += listener;
    }

    public void Unsubscribe(Action listener)
    {
        _event -= listener;
    }
}

public class CustomEvent<T>
{
    private event Action<T> _event;

    public void Invoke(T type)
    {
        _event?.Invoke(type);
    }

    public void Subscribe(Action<T> listener)
    {
        _event += listener;
    }

    public void Unsubscribe(Action<T> listener)
    {
        _event -= listener;
    }
}
