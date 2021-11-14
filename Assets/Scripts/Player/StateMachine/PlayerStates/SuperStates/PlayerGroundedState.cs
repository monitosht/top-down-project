using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 movementDirection;

    private bool dashInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {        
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.DashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        movementDirection = player.InputHandler.RawMovementInput.normalized;
        dashInput = player.InputHandler.DashInput;

        if(dashInput && player.DashState.CheckIfCanDash() && movementDirection != Vector2.zero)
        {
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
