using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStateManager : MonoBehaviour
{
    public bossBaseState currentState;
    void Start()
    {
        //currentState = idleState;
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
    public void SwitchState(bossBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
