using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{   
    private PlayerInput playerInput;
    private Vector2 crosshairPosition;
    private void Start()
    {          
        playerInput = FindObjectOfType<PlayerInput>();
    }    
    private void Update()
    {
        crosshairPosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>());
        transform.position = new Vector2(crosshairPosition.x, crosshairPosition.y);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
