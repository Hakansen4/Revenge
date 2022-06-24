using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charDeadState : charBaseState
{
    private float timer;
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        animator.SetTrigger("Dead");
        timer = Time.time;
    }

    public override void UpdateState(charStateManger charachter)
    {
        checkTimer(charachter);
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {

    }
    private void checkTimer(charStateManger charachter)
    {
        if(Time.time - timer > 2.0f)
        {
            charachter.deadScreen.SetActive(true);
        }
    }
}
