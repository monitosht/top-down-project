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
    //[SerializeField]
    private float inputHoldTime = 0.2f;
    private float dashInputStartTime;

    public bool InteractInput {get; private set;}
    public bool inventoryInput;

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

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            InteractInput = true;
        }
        else if(context.canceled)
        {
            InteractInput = false;
        }
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            inventoryInput = true;
        }
    }
}
