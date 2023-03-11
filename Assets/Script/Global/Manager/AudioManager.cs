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
    static float volum;
    static float sound= -999;
    private void Start()
    {
        if (sound == -999) sound = DataManager.DataSetting.sound;
        audioSlider.value = sound;
        masterMixer.SetFloat("BGM", sound);
    }
    public void AudioControl()
    {
        sound = audioSlider.value;
        mute.SetActive(false);
        if (sound == -40f)
        {
            mute.SetActive(true);
            masterMixer.SetFloat("BGM", -80);
        }
        else masterMixer.SetFloat("BGM", sound);
        DataManager.DataSetting.sound = sound;
    }
    public void ToggleMute()
    {
        if(isMute)
        {
            mute.SetActive(false);
            audioSlider.value = volum;
            sound = volum;
            masterMixer.SetFloat("BGM", volum);
        }
        else
        {
            mute.SetActive(true);
            sound = -80;
            volum = audioSlider.value;
            audioSlider.value = -40;
            masterMixer.SetFloat("BGM", -80);
        }
        isMute = !isMute;
        DataManager.DataSetting.sound = sound;
    }
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
