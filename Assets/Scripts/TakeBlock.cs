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
        //agarrar el objeto block y colocarlo en la posicion del hijo "TakePoint" del jugador actual
        blockTransform.position = Hand.position;
    }

    public void ReturnBlock()
    {
        blockTransform.position = blockOrignalPosition;
    }
}
