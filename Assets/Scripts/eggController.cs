using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggController : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    public void playBreakSound()
    {
        audio.Play();
    }
}
