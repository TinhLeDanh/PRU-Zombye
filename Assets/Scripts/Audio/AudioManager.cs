using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public class AudioManager
{
    private static bool _initialized = false;
    private static AudioSource _audioSource;
    private static Dictionary<AudioClipName, AudioClip> _audioClips = new();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return _initialized; }
    }
}