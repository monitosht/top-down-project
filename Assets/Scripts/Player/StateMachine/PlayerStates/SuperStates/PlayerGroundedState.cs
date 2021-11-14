using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;

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
        
        input = player.InputHandler.RawMovementInput.normalized;
        dashInput = player.InputHandler.DashInput;

        if(dashInput && player.DashState.CheckIfCanDash())
        {
            Debug.Log("again");
            stateMachine.ChangeState(player.DashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
