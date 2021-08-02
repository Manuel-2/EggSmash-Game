using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LenguageAdministrator : MonoBehaviour
{
    public static LenguageAdministrator sharedInstance;

    public Lenguages currentLenguage;
    [SerializeField] string LenguageKeyPrefs;
    [SerializeField] string TextsTags;
    public enum Lenguages
    {
        English,
        Español
    }

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString(LenguageKeyPrefs, "English") == "English"){
            currentLenguage = Lenguages.English;
        }else if(PlayerPrefs.GetString(LenguageKeyPrefs) == "Español")
        {
            currentLenguage = Lenguages.Español;
        }
    }

    public void ChangeLenguage()
    {
        if(currentLenguage == Lenguages.English)
        {
            PlayerPrefs.SetString(LenguageKeyPrefs, "Español");
            currentLenguage = Lenguages.Español;
        }
        else if (currentLenguage == Lenguages.Español)
        {
            PlayerPrefs.SetString(LenguageKeyPrefs, "English");
            currentLenguage = Lenguages.English;
        }

        UpdateTexts();
    }

    public void UpdateTexts()
    {
        //find all the texts in the scene and update the lenguage
        GameObject[] textsDisplays = GameObject.FindGameObjectsWithTag(TextsTags);
        foreach (GameObject textElement in textsDisplays)
        {
            textElement.GetComponent<TextDisplay>().ChangeTextLenguage();
        }
    }
}
