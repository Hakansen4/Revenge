using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDeadState : bossBaseState
{
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        animator.SetTrigger("Dead");
    }

    public override void UpdateState(bossStateManager boss)
    {
        
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {

    }
}
