using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    private Transform player;
    private PlayerInput playerInput;

    Vector3 target;
    Vector3 mousePosition;
    Vector3 refVel;
    Vector3 shakeOffset;

    float zPosition;

    public float viewDistance;
    public float smoothTime;

    private void Start()
    {
        zPosition = transform.position.z;
        FindPlayer();
        playerInput = player.gameObject.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        FindPlayer();
        mousePosition = CaptureMousePosition();
        target = UpdateTargetPosition();
        UpdateCameraPosition();
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private Vector3 CaptureMousePosition()
    {
        Vector2 pos = Camera.main.ScreenToViewportPoint(playerInput.actions["Aim"].ReadValue<Vector2>());
        pos *= 2;
        pos -= Vector2.one;
        float max = 0.9f;
        if (Mathf.Abs(pos.x) > max || Mathf.Abs(pos.y) > max)
        {
            pos = pos.normalized;
        }
        return pos;
    }

    private Vector3 UpdateTargetPosition()
    {
        Vector3 mouseOffset = mousePosition * viewDistance;
        Vector3 pos = player.position + mouseOffset;
        pos.z = zPosition;
        return pos;
    }

    private void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
        transform.position = tempPos;
    }
}
