using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode[] player1Inputs;
    [SerializeField] KeyCode[] player2Inputs;

    // true = player1 turn, false = player2 turn
    bool turn;

    bool inGame;

    private Actions currentState;
    enum Actions
    {
        jo,
        re,
        ev
    }

    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        turn = true;
        currentState = Actions.jo;
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame)
        {
            switch (currentState)
            {
                case Actions.jo:
                    if (turn)
                    {
                        if (Input.GetKeyDown(player1Inputs[0]))
                        {
                            PlayerAcction(Actions.jo);
                        }
                        else if (Input.GetKeyDown(player1Inputs[1]))
                        {
                            PlayerAcction(Actions.re);
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(player2Inputs[0]))
                        {
                            PlayerAcction(Actions.jo);
                        }
                        else if (Input.GetKeyDown(player2Inputs[1]))
                        {
                            PlayerAcction(Actions.re);
                        }
                    }
                    break;
                case Actions.re:
                    if (turn)
                    {
                        if (Input.GetKeyDown(player1Inputs[2]))
                        {
                            PlayerAcction(Actions.ev);
                        }
                        else if (Input.GetKeyDown(player1Inputs[0]))
                        {
                            PlayerAcction(Actions.jo);
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(player2Inputs[2]))
                        {
                            PlayerAcction(Actions.ev);
                        }
                        else if (Input.GetKeyDown(player2Inputs[0]))
                        {
                            PlayerAcction(Actions.jo);
                        }
                    }
                    break;
                case Actions.ev:
                    PlayerAcction(Actions.jo);
                    break;
            }
        }
    }

    void PlayerAcction(Actions action)
    {
        turn = !turn;

            switch (currentState)
            {
                case Actions.jo:
                    switch (action)
                    {
                        case Actions.jo:
                            currentState = Actions.jo;
                            break;
                        case Actions.re:
                            currentState = Actions.re;
                            break;
                    }
                    break;
                case Actions.re:
                    switch (action)
                    {
                        case Actions.ev:
                            currentState = Actions.ev;
                            break;
                        case Actions.jo:
                        //game over XD
                        inGame = false;
                            break;
                    }
                    break;
                case Actions.ev:
                    // caso especial cuando un jugador usa ev, es como omitir su sig turno y vuelve a jo el cual es el estado por defecto
                    currentState = Actions.jo;
                    break;

            }
    }
}
