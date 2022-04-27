using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStateManager : MonoBehaviour
{
    #region States
    public bossBaseState currentState;
    public bossWalkingState walkState = new bossWalkingState();
    public bossCombatState combatState = new bossCombatState();
    public bossDashState dashState = new bossDashState();
    public bossS_AttackState S_AttackState = new bossS_AttackState();
    public bossDeadState deadState = new bossDeadState();
    #endregion
    public float combatRange;
    public float AttackTime;
    public float dashAnimTime;
    public float S_AttackAnimTime;
    public float S_AttackCooldown;

    void Start()
    {
        currentState = walkState;
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
