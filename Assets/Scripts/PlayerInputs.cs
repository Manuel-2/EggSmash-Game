using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] KeyCode[] player1Inputs;
    [SerializeField] KeyCode[] player2Inputs;

    [Header("Player Animators")]
    [SerializeField] Animator player1Anim;
    [SerializeField] Animator player2Anim;

    [Header("Movement Triggers")]
    [SerializeField] string joTrigger;
    [SerializeField] string reTrigger;
    [SerializeField] string evTrigger;

    // true = player1 turn, false = player2 turn
    bool turn;

    // es verdadero si un jugador perdio
    bool gameOver;

    // es falso si un jugador efectua un movimiento
    bool inGame;

    public Actions currentState { get; private set; }
    public enum Actions
    {
        jo,
        re,
        ev
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        inGame = true;
        turn = true;
        currentState = Actions.jo;
    }

    // Update is called once per frame
    void Update()
    {
        //Todo: el segundo jugador no puede efectuar sus moviminetos hasta que la animaciones del jugador 1 terminen
        if (inGame && gameOver == false)
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
        MovePlayer(action);

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
                        GameOver();
                            break;
                    }
                    break;
                case Actions.ev:
                    // caso especial cuando un jugador usa ev, es como omitir su sig turno y vuelve a jo el cual es el estado por defecto
                    // ejecutar una funcion para que el player regrese el tazon
                    //current state = Actions.jo
                    currentState = action;
                    break;

            }

        //turn = !turn;
    }

    private void MovePlayer(Actions action)
    {
        switch (action)
        {
            case Actions.jo:
                if (turn)
                {
                    player1Anim.SetTrigger(joTrigger);
                }
                else
                {
                    player2Anim.SetTrigger(joTrigger);
                }
                break;
            case Actions.re:
                if (turn)
                {
                    player1Anim.SetTrigger(reTrigger);
                }
                else
                {
                    player2Anim.SetTrigger(reTrigger);
                }
                break;
            case Actions.ev:
                if (turn)
                {
                    player1Anim.SetTrigger(evTrigger);
                }
                else
                {
                    player2Anim.SetTrigger(evTrigger);
                }
                break;
        }
        // con esto en false se dejan de tomar en cuenta los inputs de ambos jugadores asta que el turno del jugador termine(al final de la animacion de su movimiento)
        inGame = false;
    }

    private void GameOver()
    {
        //cuando esto es verdadero el juego deja de leer los inputs de los jugadores
        gameOver = true;
        //esto es true porque al finalizar el turno del jugador se invierte y este metodo se ejecuta antes, por lo cual esto revierte  el estado revertido
        inGame = true;

        Debug.Log("juego terminado");
    }


    public void nextTurn()
    {
        inGame = true;
        turn = !turn;
    }

}
