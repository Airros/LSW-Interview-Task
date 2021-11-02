using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;

    Rigidbody2D myRigidbody;

    public Vector2 movement;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        moveCharacter();
    }

    //Gets the player Inputs
    void getInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    
    //Move the Player entity using the inputs
    void moveCharacter()
    {
        myRigidbody.MovePosition(myRigidbody.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
