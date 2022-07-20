using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossS_AttackState : bossBaseState
{
    private float S_AttackTimer;
    private float S_AttackAnimLong;
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        animator.SetTrigger("S_Attack");
        S_AttackAnimLong = boss.S_AttackAnimTime;
        S_AttackTimer = Time.time;
        Debug.Log(S_AttackAnimLong);
    }

    public override void UpdateState(bossStateManager boss)
    {
        checkAnimTime(boss);
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {

    }
    private void checkAnimTime(bossStateManager boss)
    {
        if(Time.time - S_AttackTimer > S_AttackAnimLong)
        {
            Debug.Log("Girdi");
            boss.SwitchState(boss.combatState);
        }
    }
}
