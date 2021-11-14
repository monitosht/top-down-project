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
        crosshairPosition = Camera.main.ScreenToWorldPoint(playerInput.actions["Aim"].ReadValue<Vector2>());

        if(playerInput.currentControlScheme == "Gamepad")
        {
            crosshairPosition = playerInput.actions["Aim"].ReadValue<Vector2>() + (Vector2)player.transform.position;
            opacity.a = 0.1f;
            GetComponent<SpriteRenderer>().color = opacity;
            //sprite.enabled = false;
        }
        else
        {
            opacity.a = 1f;
            GetComponent<SpriteRenderer>().color = opacity;
            //sprite.enabled = true;
        }

        transform.position = new Vector2(crosshairPosition.x, crosshairPosition.y);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
