using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charHittedState : charBaseState
{
    private float hitTimer;
    private float hitTime;
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        animator.SetTrigger("Hit");
        hitTimer = Time.time;
    }

    public override void UpdateState(charStateManger charachter)
    {
        checkAnimFinished(charachter);
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {

    }

    private void checkAnimFinished(charStateManger charachter)
    {
        if(Time.time - hitTimer >= hitTime)
            charachter.SwitchState(charachter.idleState);
    }
}