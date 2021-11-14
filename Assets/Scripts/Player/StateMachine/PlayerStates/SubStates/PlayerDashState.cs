using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash {get; private set;}

    private float lastDashTime;
    private Vector2 dashDirection;
    private bool dashInputStop;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        player.InputHandler.UseDashInput();
        
        dashDirection = player.InputHandler.RawMovementInput;
        dashInputStop = player.InputHandler.DashInputStop;

        player.RB.drag = playerData.drag;
        player.SetVelocity(playerData.dashVelocity, dashDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;


}
