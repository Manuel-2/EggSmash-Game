using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialConfiguration : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}