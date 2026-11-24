using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody;
    public float playerSpeed;
    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        
        Vector2 playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            playerInput.x += 1f * playerSpeed;
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            playerInput.x -= 1f * playerSpeed;
        }

        MovementUpdate(playerInput);
    }

    public void MovementUpdate(Vector2 playerInput)
    {
        Rigidbody.linearVelocity = playerInput;
    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
