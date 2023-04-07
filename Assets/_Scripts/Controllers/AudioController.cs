using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : StaticInstance<AudioController>
{
    [SerializeField]private List<AudioClip> bgmSource; // Reference to the audio source for background music
    [SerializeField]private List<AudioClip> sfxClips; //List of audio clips for sound effects

    // Property for accessing the background music source
    public List<AudioClip> BGMSource
    {
        get { return bgmSource; }
        set { bgmSource = value; }
    }

    // Property for accessing the sound effects clips
    public List<AudioClip> SFXClips
    {
        get { return sfxClips; }
        set { sfxClips = value; }
    }
}
