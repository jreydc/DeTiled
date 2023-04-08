using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistentSingleton<AudioManager>
{
    [SerializeField]private AudioSource bgmSource; // Reference to the audio source for background music
    [SerializeField]private AudioSource sfxSource; // Reference to the audio source for sound effects

    // Play background music
    public void PlayBGM(AudioClip clip, float volume = 0.5f)
    {
        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // Pause background music
    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    // Resume background music
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    // Stop background music
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // Adjust background music volume
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    // Play sound effect
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    // Adjust sound effects volume
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

