using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{   
    public PlayerInputHandler InputHandler {get; private set;}
    public PlayerInput playerInput;
    private Vector2 crosshairPosition;
    private void Start()
    {          
        InputHandler = FindObjectOfType<PlayerInputHandler>();
    }    
    private void Update()
    {
        //crosshairPosition = Camera.main.ScreenToWorldPoint(InputHandler.MousePosition);
        crosshairPosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>());
        transform.position = new Vector2(crosshairPosition.x, crosshairPosition.y);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
