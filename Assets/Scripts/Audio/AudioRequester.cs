using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioRequestType
{
    PLAY_FX,
    PLAY_MUSIC,
    SETTING
}

[System.Serializable]
public struct AudioRequest
{
    public AudioRequestType Type;
    public string Name;
    [Range(0,1)]
    public float Volume;
    public bool EnableMusic;
}

public class AudioRequester : MonoBehaviour
{
    [SerializeField] private GameEvent audioRequestEvent;
    public AudioRequest audioRequest;

    public void RequestAudio()
    {
        audioRequestEvent.Raise(this, audioRequest);
    }
}
