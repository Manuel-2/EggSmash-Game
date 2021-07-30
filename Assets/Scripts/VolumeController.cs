using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeController : MonoBehaviour
{ 
    [SerializeField] Slider slider;
    [SerializeField] float sliderValue;
    [SerializeField] Image muteIcon;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("AudioVolume", 0.7f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("AudioVolume", sliderValue);
        AudioListener.volume = Mathf.Pow(sliderValue, 2);
        CheckMute();
    }

    public void CheckMute()
    {
        if (sliderValue == 0)
        {
            muteIcon.enabled = true;
        }
        else
        {
            muteIcon.enabled = false;
        }
    }
}
