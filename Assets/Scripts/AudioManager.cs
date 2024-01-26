using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource audioSource, sfxSource;


    private void Start()
    {

    }
    public void PlayMusic(string namesound)
    {
        Sound s = Array.Find(musicSounds, x => x.namesound == namesound);
        if (s == null)
        {
            Debug.Log("Sound Not Sound");
        }
        else
        {
            audioSource.clip = s.clip;
            audioSource.Play();
        }
    }
    public void PlaySFX(string namesound)
    {
        Sound s = Array.Find(sfxSounds, x => x.namesound == namesound);
        if (s == null)
        {
            Debug.Log("Sound Not Sound");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
    public void ToogleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }

    public void ToogleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        audioSource.volume = volume;

    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;

    }



}

