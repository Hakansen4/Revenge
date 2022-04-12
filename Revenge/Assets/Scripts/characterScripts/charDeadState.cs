using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charDeadState : charBaseState
{
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        animator.SetTrigger("Dead");
    }

    public override void UpdateState(charStateManger charachter)
    {

    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {

    }
}
