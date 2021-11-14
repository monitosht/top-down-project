using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{   
    private PlayerInput playerInput;
    private Camera cam;
    public Vector2 MousePosition {get; private set;}

    public Vector2 RawMovementInput {get; private set;}
    public bool DashInput {get; private set;}
    public bool DashInputStop {get; private set;}

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    private void Update()
    {
        CheckDashInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        /*if(context.started)
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
        }*/
    }

    /**public void OnAim(InputAction.CallbackContext context)
    {
        MousePosition = context.ReadValue<Vector2>();

        /*if(playerInput.currentControlScheme == "Keyboard")
        {
            MousePosition = cam.ScreenToWorldPoint(MousePosition);
        }

        Debug.Log(MousePosition);
    }*/

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

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }        
    }
}
