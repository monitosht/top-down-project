using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementSpeed = 10f;

    [Header("Move State")]
    public float dashCooldown = 1f;
    public float dashTime = 0.1f;
    public float dashVelocity = 30f;
    public float drag = 10f;
}
