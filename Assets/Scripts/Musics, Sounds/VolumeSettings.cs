using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderMaster;
    public Slider sliderMusic;
    public Slider sliderSFX;

    void Start()
    {
        float master = PlayerPrefs.GetFloat("VolMaster", 1f);
        float music = PlayerPrefs.GetFloat("VolMusic", 1f);
        float sfx = PlayerPrefs.GetFloat("VolSFX", 1f);

        sliderMaster.value = master;
        sliderMusic.value = music;
        sliderSFX.value = sfx;
    }

    public void SetMaster()
    {
        mixer.SetFloat("MasterVolume", sliderMaster.value);
    }

    public void SetMusic()
    {
        mixer.SetFloat("MusicVolume", sliderMusic.value);
    }

    public void SetSFX()
    {
        mixer.SetFloat("SFXVolume", sliderSFX.value);
    }
}