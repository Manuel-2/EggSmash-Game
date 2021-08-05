using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayerDetectionMobile : MonoBehaviour
{
    [SerializeField] InputTypes input;
    // 0 = null ||  1 = player1 & 2 = player2
    [SerializeField] int playerReInput;

    private enum InputTypes
    {
        Jo,
        Re,
        Ev
    }

    private void OnMouseDown()
    {
        if (PlayerInputs.sharedInstance.inGame && PlayerInputs.sharedInstance.gameOver == false)
        {
            if (input == InputTypes.Jo)
            {
                if (PlayerInputs.sharedInstance.currentState == PlayerInputs.Actions.jo || PlayerInputs.sharedInstance.currentState == PlayerInputs.Actions.re)
                {
                    PlayerInputs.sharedInstance.PlayerAcction(PlayerInputs.Actions.jo);
                }
            }
            else if (input == InputTypes.Re)
            {
                if (PlayerInputs.sharedInstance.currentState == PlayerInputs.Actions.jo)
                {
                    if (playerReInput == 1 && PlayerInputs.sharedInstance.turn)
                    {
                        PlayerInputs.sharedInstance.PlayerAcction(PlayerInputs.Actions.re);
                    }
                    else if (playerReInput == 2 && PlayerInputs.sharedInstance.turn == false)
                    {
                        PlayerInputs.sharedInstance.PlayerAcction(PlayerInputs.Actions.re);
                    }
                }
            }
            else if (input == InputTypes.Ev)
            {
                if (PlayerInputs.sharedInstance.currentState == PlayerInputs.Actions.re)
                {
                    PlayerInputs.sharedInstance.PlayerAcction(PlayerInputs.Actions.ev);
                }
            }
        }
    }

}
