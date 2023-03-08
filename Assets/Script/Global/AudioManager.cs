using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] GameObject mute;
    bool isMute = false;
    float volum;
    public void AudioControl()
    {
        float sound = audioSlider.value;
        mute.SetActive(false);
        if (sound == -40f)
        {
            mute.SetActive(true);
            masterMixer.SetFloat("BGM", -80);
        }
        else masterMixer.SetFloat("BGM", sound);
    }
    public void ToggleMute()
    {
        if(isMute)
        {
            mute.SetActive(false);
            audioSlider.value = volum; 
            masterMixer.SetFloat("BGM", volum);
        }
        else
        {
            mute.SetActive(true);
            volum = audioSlider.value;
            audioSlider.value = -40;
            masterMixer.SetFloat("BGM", -80);
        }
        isMute = !isMute;
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
