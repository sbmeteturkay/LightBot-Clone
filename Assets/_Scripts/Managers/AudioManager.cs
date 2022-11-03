using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Jump,
            Resources.Load<AudioClip>("Sounds/Jump"));
    }
    public static void Play(AudioClipName name,float volume=1)
    {
        audioSource.PlayOneShot(audioClips[name],volume);
    }
}
