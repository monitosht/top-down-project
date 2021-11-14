using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{   
    public PlayerInputHandler InputHandler {get; private set;}
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        InputHandler = FindObjectOfType<PlayerInputHandler>().GetComponent<PlayerInputHandler>();
    }    
    private void Update()
    {
        transform.position = new Vector2(InputHandler.MousePosition.x, InputHandler.MousePosition.y);
    }
}
