using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] Slider slider;
    float reactionTime;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("GameSpeed", 2f);
        reactionTime = slider.value;
    }

    public void ChangeGameSpeed(float time)
    {
        reactionTime = time;
        PlayerPrefs.SetFloat("GameSpeed", reactionTime);
    }
}
