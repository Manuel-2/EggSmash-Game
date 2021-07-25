using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] GameObject inGameUI;
    [Space]
    [SerializeField] GameObject gameEndedUI;
    [SerializeField] GameObject[] signs;
    [Space]
    [SerializeField] GameObject preGameUI;

    [Header("Scenes Names")]
    [SerializeField] string mainMenuScene;
    [SerializeField] string gameScene;

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

    public void RetryGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
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
