using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSliderConfiguration : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = PlayerInputs.sharedInstance.initialReactionTime * 2;
        slider.value = PlayerInputs.sharedInstance.initialReactionTime;
    }

}
