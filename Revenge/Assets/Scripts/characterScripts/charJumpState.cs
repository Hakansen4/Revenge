using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charJumpState : charBaseState
{
    private bool canJump;
    public override void EnterState(charStateManger charachter)
    {
        canJump = true;
        addComponents(charachter);
        jump();
    }

    public override void UpdateState(charStateManger charachter)
    {
        move();
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {
        canJump = false;
        charachter.SwitchState(charachter.idleState);
    }

    private void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        trnsfrm.position += new Vector3(horizontal * speed * Time.deltaTime,0,0);
        if(horizontal < 0)
            trnsfrm.localScale = new Vector3(-1,1,0);
        else if(horizontal > 0)
            trnsfrm.localScale = new Vector3(1,1,0);
    }
    private void jump()
    {
        if(canJump)
            {
                animator.SetTrigger("isJumping");
                physic.AddForce(new Vector2(0, jumpPower));
                canJump = false;
            }
    }
}
