using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialConfiguration : MonoBehaviour
{
    public static CameraInitialConfiguration sharedInstance;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}