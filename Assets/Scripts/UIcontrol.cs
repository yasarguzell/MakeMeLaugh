using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontrol : MonoBehaviour
{
    public Slider _musicslider, _sfxslider;
    public float _musicslidervalue, _sfxslidervalue;

    public void ChangeSliderMusic(float value)
    {
        _musicslidervalue = value;
    }

    public void ChangeSliderSFX(float value)
    {
        _sfxslidervalue = value;
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToogleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToogleSFX();
    }
    public void MusicVolume(float volume)
    {
        AudioManager.Instance.MusicVolume(_musicslider.value);



    }
    public void SFXVolume(float volume)
    {
        AudioManager.Instance.SFXVolume(_sfxslider.value);

    }
}
