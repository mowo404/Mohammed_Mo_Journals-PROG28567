using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float accelerationTime;
    private float acceleration;
    public Rigidbody2D Rigidbody;
    public float playerSpeed;
    public enum FacingDirection
    {
        left, right
    }
    //variable to store the current direction
    public FacingDirection facingDirection;

    void Start()
    {
        //assign the rigidbody component to the variable itself
        Rigidbody = GetComponent<Rigidbody2D>();
        //declare accerlation variable
        acceleration = maxSpeed / accelerationTime;

    }

    void Update()
    {
        //declaring player input variable
        Vector2 playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        
        //basic player movement script that increases the x value when left and right arrow is pressed
        if(Keyboard.current.leftArrowKey.isPressed)
        {
            //increase x position by 1 and the speed set in the explorer
            playerInput.x += 1f * playerSpeed;
            //change the direction when the left arrow is pressed
            facingDirection = FacingDirection.right;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            //increase x position by 1 and the speed set in the explorer
            playerInput.x -= 1f * playerSpeed;
            //change the direction when the right arrow is pressed
            facingDirection = FacingDirection.left;
        }

        MovementUpdate(playerInput);
    }

    public void MovementUpdate(Vector2 playerInput)
    {
        //change the position of the rigidbody when movement update is run
        Vector2 rbVelocity = Rigidbody.linearVelocity;
        if (playerInput.x != 0)
        {
            //accelerate the player if the x position is changed in update
            rbVelocity += playerInput * acceleration * Time.deltaTime;
        }
        Rigidbody.linearVelocity = rbVelocity;
    }
    public bool IsWalking(Vector2 playerInput)
    {
        //when x position is changed then change isWalking to true
        if (playerInput.x != 0) 
        { 
            return true; 
        } else
        {
            return false;
        }
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
       
        return facingDirection;
       
            
    }
}
