using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charStateManger : MonoBehaviour
{
    public static charStateManger instance;

    public GameObject deadScreen;

    #region Flags
    public bool FLAG_MOVE;
    public bool FLAG_ATTACK;
    #endregion

    #region States
    public charBaseState currentState;
    public charIdleState idleState = new charIdleState();
    public charMovingState movingState = new charMovingState();
    public charJumpState jumpState = new charJumpState();
    public charDashState dashState = new charDashState();
    public charDeadState deadState = new charDeadState();
    public charHittedState hittedState = new charHittedState();
    public charRestState restState = new charRestState();
    #endregion
    private void Awake()
    {
        Init();
        instance = this;
    }
    private void Init()
    {
        FLAG_MOVE = true;
        FLAG_ATTACK = true;
    }
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        currentState.OnCollisionEnter2D(this,collisionInfo);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(charBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
