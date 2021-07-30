using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] float speed;
    [SerializeField] Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = movementDirection.normalized * speed;
    }

    private void Update()
    {
        if(transform.position.x <= -3)
        {
            transform.position = new Vector3(0,0,0); 
        }
    }

}
