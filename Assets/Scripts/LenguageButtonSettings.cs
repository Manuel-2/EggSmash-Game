using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LenguageButtonSettings : MonoBehaviour
{
    public void ChangeLenguage()
    {
        LenguageAdministrator.sharedInstance.ChangeLenguage();
    }
}
