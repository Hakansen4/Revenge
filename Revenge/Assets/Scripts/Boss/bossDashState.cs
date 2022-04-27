using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDashState : bossBaseState
{
    private float animTimer = 0;
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        animator.SetTrigger("dash");
        animTimer = Time.time;
    }

    public override void UpdateState(bossStateManager boss)
    {
        dashMove();
        checkAnimFinished(boss);
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {

    }
    private void checkAnimFinished(bossStateManager boss)
    {
        if(Time.time - animTimer > boss.dashAnimTime)
            boss.SwitchState(boss.combatState);
    }
}