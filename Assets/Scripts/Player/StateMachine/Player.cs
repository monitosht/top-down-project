using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine {get; private set;}
    public PlayerIdleState IdleState {get; private set;}
    public PlayerMoveState MoveState {get; private set;}
    public PlayerDashState DashState {get; private set;}

    [SerializeField] 
    private PlayerData playerData;   
    #endregion

    #region Component Variables
    //public Animator Anim {get; private set;}
    public PlayerInputHandler InputHandler {get; private set;}
    public Rigidbody2D RB {get; private set;}

    #endregion

    #region Movement Variables
    public Vector2 CurretVelocity {get; private set;}
    public int FacingDirection {get; private set;}
    private Vector2 workspace;
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        MoveState = new PlayerMoveState(this, StateMachine, playerData);
        DashState = new PlayerDashState(this, StateMachine, playerData);
    }

    private void Start()
    {
        //Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initilaize(IdleState);
    }

    private void Update()
    {        
        CurretVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocity(Vector2 velocity)
    {
        workspace.Set(velocity.x, velocity.y);
        RB.velocity = workspace;
        CurretVelocity = workspace;
    }
    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;        
        RB.velocity = workspace;
        CurretVelocity = workspace;
    }
    #endregion

    #region Check Functions
    public void CheckFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    #endregion

    #region Other Functions
    private void Flip()
    {
        FacingDirection += -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion
}
