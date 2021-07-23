using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBlock : MonoBehaviour
{
    [SerializeField] Vector3 blockOrignalPosition;
    [SerializeField] Transform blockTransform;
    [SerializeField] Transform Hand;

    [SerializeField] PlayerInputs playerInputs;


    public void EndPlayerTurn()
    {
        playerInputs.nextTurn();
    }

    public void GrabBlock()
    {
        //TODO: hacer que el bloque sea un hijo del jugador
        blockTransform.position = Hand.position;
    }

    public void ReturnBlock()
    {
        if(playerInputs.currentState != PlayerInputs.Actions.re)
        {
            blockTransform.position = blockOrignalPosition;
        }
    }
}
