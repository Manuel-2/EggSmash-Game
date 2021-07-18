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
        zero,
        jo,
        re,
        ev
    }

    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
        turn = true;
        currentState = Actions.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (inGame)
        {
            //TODO: segun el ultimo movimento no puedes hacer ciertas acciones, por ejemplo en un Jo no tiene sendo un Ev
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
                else if (Input.GetKeyDown(player1Inputs[2]))
                {
                    PlayerAcction(Actions.ev);
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
                else if (Input.GetKeyDown(player2Inputs[2]))
                {
                    PlayerAcction(Actions.ev);
                }
            }
        }
    }

    void PlayerAcction(Actions action)
    {
        if(currentState == Actions.zero)
        {
            currentState = action;
        }
        else
        {
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
                            break;
                    }
                    break;
                case Actions.ev:
                    // caso especial cuando un jugador usa ev, es como omitir su sig turno, si el otro jugador esquiva el Re y usa ev lo que te queda por hacer es devolver "tason"
                    currentState = Actions.zero;
                    break;

            }
        }
    }
}
