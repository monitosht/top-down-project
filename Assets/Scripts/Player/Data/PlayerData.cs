using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Stats")]
    public int health;
    public int inventorySize;

    [Header("Move State")]
    public float movementSpeed = 10f;

    [Header("Dash State")]
    public float dashCooldown = 1f;
    public float dashTime = 0.1f;
    public float dashVelocity = 30f;
    public float drag = 10f;
}


