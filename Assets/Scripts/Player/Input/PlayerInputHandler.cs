using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{   
    public Vector2 RawMovementInput {get; private set;}
    public int NormInputX {get; private set;}
    public int NormInputY {get; private set;}

    public Vector2 MousePosition {get; private set;}
    public GameObject crosshair;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        
        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;        
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("jump pressed");
        }
        if(context.performed)
        {
            Debug.Log("jump held");
        }
        if(context.canceled)
        {
            Debug.Log("jump released");
        }        
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        MousePosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());              
    }

}
