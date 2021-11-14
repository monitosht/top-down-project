using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{   
    public Vector2 RawMovementInput {get; private set;}
    public bool DashInput {get; private set;}
    public bool DashInputStop {get; private set;}
    
    [SerializeField]
    private float inputHoldTime = 0.2f;
    private float dashInputStartTime;

    private void Update()
    {
        CheckDashTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
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

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if(context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void UseDashInput() => DashInput = false;

    private void CheckDashTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}
