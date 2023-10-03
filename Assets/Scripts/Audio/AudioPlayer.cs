using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameEventListener))]
public class AudioPlayer : MonoBehaviour
{
    
    private GameEventListener audioEventListener;
    private AudioSource fxSource;
    private AudioSource musicSource;
    private List<AudioClip> loadedClips;

    void Awake()
    {
        audioEventListener = GetComponent<GameEventListener>();
        fxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        loadedClips = new List<AudioClip>();
    }

    public void OnAudioRequest(Component sender, object data)
    {
        if(data is AudioRequest)
        {
            AudioRequest request = (AudioRequest) data;
            ProcessAudioRequest(request);
        }
    }

    private void ProcessAudioRequest(AudioRequest request)
    {
        AudioSource source = fxSource;
        switch(request.Type)
        {
            case AudioRequestType.PLAY_FX:
                source = fxSource;
                break;
            case AudioRequestType.PLAY_MUSIC:
                source = musicSource;
                break;
            case AudioRequestType.SETTING:
                return;
            default:
                break;
        }
        source.volume = request.Volume;
        PlayAudio(request.Name, source);
    }

    void PlayAudio(string name, AudioSource source)
    {
        AudioClip clip = GetAudioClip(name);
        if(clip != null && !source.isPlaying)
        {
            source.PlayOneShot(clip);
        }
    }

    AudioClip GetAudioClip(string name)
    {
        AudioClip retClip;

        // First see if we've loaded this clip already
        retClip = loadedClips.Find(x => x.ToString() == name);
        if(retClip != null)
        {
            return retClip;
        }

        // Then load the clip if needed and add to list if it exists
        retClip = Resources.Load<AudioClip>("Audio/" + name);
        if(retClip != null)
        {
            loadedClips.Add(retClip);
            return retClip;
        }

        // Can't find clip
        Debug.Log("Error: Audio clip not found (name typed wrong?)");
        return retClip;
    }

}
