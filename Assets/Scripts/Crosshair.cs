using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{   
    private SpriteRenderer sprite;
    private Color opacity;
    private GameObject player;
    private PlayerInput playerInput;
    private PlayerInputHandler playerInputHandler;
    private Vector2 crosshairPosition;
    private Vector2 mousePosition;
    public float scaleValue;
    private void Start()
    {        
        sprite = GetComponent<SpriteRenderer>();
        opacity = sprite.color;
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = FindObjectOfType<PlayerInput>();
        playerInputHandler = FindObjectOfType<PlayerInputHandler>();
    }    
    private void Update()
    {   
        mousePosition = playerInput.actions["Aim"].ReadValue<Vector2>();
        crosshairPosition = Camera.main.ScreenToWorldPoint(mousePosition);   

        if(playerInput.currentControlScheme == "Gamepad")
        {
            crosshairPosition = (mousePosition.normalized * scaleValue) + (Vector2)player.transform.position;
        }
        transform.position = new Vector2(crosshairPosition.x, crosshairPosition.y);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        
        UpdateVisibility();   
    }

    private void UpdateVisibility()
    {
        if(playerInput.currentControlScheme == "Gamepad")
        {
            if(mousePosition == Vector2.zero)
            {
                sprite.enabled = false;
            }
            else
            {
                sprite.enabled = true;
            }
            opacity.a = 0.75f;
            GetComponent<SpriteRenderer>().color = opacity;
            
        }
        else
        {
            sprite.enabled = true;
            opacity.a = 1f;
            GetComponent<SpriteRenderer>().color = opacity;            
        }   
    }
}
