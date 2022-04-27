using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossWalkingState : bossBaseState
{
    private float speed = 2;

    #region Dash Works
    private float dashDistance = 5;
    private float dashTimer = 0;
    private float dashCooldown = 7;
    private bool isDashed = true;
    #endregion
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        animator.SetBool("Walking",true);
    }

    public override void UpdateState(bossStateManager boss)
    {
        walk();
        checkDirection();
        checkDistance(boss);
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {
        
    }
    private void walk()
    {
        trnsfrm.position = Vector2.MoveTowards(trnsfrm.position,playerPosition.position,speed * Time.deltaTime);
    }
    private void checkDistance(bossStateManager boss)
    {
        if(trnsfrm.position.x - playerPosition.position.x <= boss.combatRange    &&
            trnsfrm.position.x - playerPosition.position.x >= -boss.combatRange)
        {
            animator.SetBool("Walking",false);
            boss.SwitchState(boss.combatState);
        }
        else if(trnsfrm.position.x - playerPosition.position.x >= dashDistance    ||
            trnsfrm.position.x - playerPosition.position.x <= -dashDistance)
        {
            if(checkDash())
            {
                animator.SetBool("Walking",false);
                boss.SwitchState(boss.dashState);
            }
        }
    }
    private bool checkDash()
    {
        if(Time.time - dashTimer > dashCooldown)
        {
            dashTimer = Time.time;
            return true;
        }
        else
            return false;
    }
}