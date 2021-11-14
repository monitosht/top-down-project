using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash {get; private set;}
    private float lastDashTime;
    private Vector2 dashDirection;
    private bool dashInputStop;    
    private bool isHolding;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;

        dashDirection = player.InputHandler.RawMovementInput.normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();     

        if(isHolding)
        {
            dashInputStop = player.InputHandler.DashInputStop;   

            if(dashInputStop)
            {
                isHolding = false;
                startTime = Time.time;
                player.RB.drag = playerData.drag;
                player.SetDashVelocity(playerData.dashVelocity, dashDirection);
            }
        }
        else
        {            
            player.SetDashVelocity(playerData.dashVelocity, dashDirection);

            if(Time.time >= startTime + playerData.dashTime)
            {                
                player.RB.drag = 0f;
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
        }  
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;
}
