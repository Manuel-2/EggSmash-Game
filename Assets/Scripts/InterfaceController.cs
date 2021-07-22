using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] GameObject inGameUI;
    [Space]
    [SerializeField] GameObject gameEndedUI;
    [SerializeField] GameObject[] signs;
    [Space]
    [SerializeField] GameObject preGameUI;


    public void StartGame()
    {
        ShowInGameInterface();
        PlayerInputs.sharedInstance.StartGame();
    }

    public void ShowInGameInterface()
    {
        preGameUI.SetActive(false);
        inGameUI.SetActive(true);
    }


    // player 1 = true  | player 2 = false
    public void showGameOverInterface(bool player)
    {
        inGameUI.SetActive(false);
        gameEndedUI.SetActive(true);

        if (player)
        {
            signs[0].SetActive(true);
            signs[1].SetActive(false);
        }
        else
        {
            signs[0].SetActive(false);
            signs[1].SetActive(true);
        }

    }

}
