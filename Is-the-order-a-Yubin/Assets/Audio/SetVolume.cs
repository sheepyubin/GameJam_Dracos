using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioMixer mixer;
    public Slider MasterSlider;
    public Slider BackSlider;
    public Slider EffectSlider;
    
    void Awake()
    {
        MasterSlider.onValueChanged.AddListener(SetMasterVolume);
        BackSlider.onValueChanged.AddListener(SetBackVolume);
        EffectSlider.onValueChanged.AddListener(SetEffectVolume);
    }

    public void SetMasterVolume(float volume)
    {
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetBackVolume(float volume)
    {
        mixer.SetFloat("Back", Mathf.Log10(volume) * 20);
    }

    public void SetEffectVolume(float volume)
    {
        mixer.SetFloat("Effect", Mathf.Log10(volume) * 20);
    }
}
