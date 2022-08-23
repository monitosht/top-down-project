using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    float zStart;
    public float cameraDist, smoothTime;

    Transform player;
    Vector3 target, mousePos, refVel, shakeOffset;

    void Start()
    {
        zStart = transform.position.z; //capture starting z position
    }

    void Update()
    {
        FindPlayer();
        target = player.position;

        mousePos = CaptureMousePos();
        target = UpdateTargetPos();
        UpdateCameraPosition();
    }

    Vector3 CaptureMousePos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        //Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition); DEBUG: OLD INPUT SYSTEM / INCORRECT

        ret *= 2;
        ret -= Vector2.one;
        float max = 0.9f;

        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized;
        }
        return ret;
    }

    Vector3 UpdateTargetPos()
    {
        Vector3 mouseOffset = mousePos * cameraDist; //mult mouse vector by distance scalar 
        Vector3 ret = player.position + mouseOffset; //find position as it relates to the player
        ret += shakeOffset; //add the screen shake vector to the target
        ret.z = zStart; //make sure camera stays at same Z coord
        return ret;
    }

    void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime); //smoothly move towards the target
        transform.position = tempPos; //update the position
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
