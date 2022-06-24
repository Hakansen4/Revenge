using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charDashState : charBaseState
{
    private bool isGoingRight;
    private float timer;
    private float dashSpeed = 6;
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        charachter.GetComponent<charClimb>().enabled = false;
        checkDirection();
        dash(charachter);
    }

    public override void UpdateState(charStateManger charachter)
    {
        checkTimer(charachter);
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {

    }
    private void dash(charStateManger charachter)
    {
        if(isGoingRight)
            physic.velocity = Vector2.right * dashSpeed;
        else
            physic.velocity = Vector2.left * dashSpeed;
        physic.gravityScale = 0;
        trnsfrm.position -= new Vector3(0,0.5f,0);
        animator.SetTrigger("Dash");
        timer = Time.time;
    }
    private void checkDirection()
    {
        if(trnsfrm.localScale.x == 1)
        {
            isGoingRight = true;
        }
        else 
            isGoingRight = false;
    }
    private void checkTimer(charStateManger charachter)
    {
        if(Time.time - timer > 0.5f)
        {
            physic.velocity = Vector2.zero;
            physic.gravityScale = 1;
            charachter.GetComponent<charClimb>().enabled = true;
            charachter.SwitchState(charachter.idleState);
        }
    }
}