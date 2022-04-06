using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charStateManger : MonoBehaviour
{
    public charBaseState currentState;
    public charIdleState idleState = new charIdleState();
    //public charJumpingState jumpingState = new charJumpingState();
    public charMovingState movingState = new charMovingState();
    public charJumpState jumpState = new charJumpState();

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
