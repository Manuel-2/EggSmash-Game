using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    // 0 = English
    // 1 = Español
    [SerializeField] [TextArea] string[] textValues;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTextLenguage();
    }

    public void ChangeTextLenguage()
    {
        if(LenguageAdministrator.sharedInstance.currentLenguage == LenguageAdministrator.Lenguages.English)
        {
            textComponent.text = textValues[0];
        }else if (LenguageAdministrator.sharedInstance.currentLenguage == LenguageAdministrator.Lenguages.Español)
        {
            textComponent.text = textValues[1];
        }
        Debug.Log("componenete de texto actualizado");
    }
}
