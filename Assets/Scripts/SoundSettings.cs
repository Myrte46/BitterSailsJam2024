using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private AudioMixer masterMixer;

    private void Start()
    {
        SetSoundVolume(PlayerPrefs.GetFloat("SoundVolume", 100));
    }

    public void SetSoundVolume(float soundVolume)
    {
        if (soundVolume < 1){
            soundVolume = .001f;
        }

        RefreshSlider(soundVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(soundVolume/100) * 20f);
    }

    private void RefreshSlider(float soundVolume)
    {
        soundSlider.value = soundVolume;
    }

    public void SetVolumeFromSlider(){
        SetSoundVolume(soundSlider.value);
    }
}
