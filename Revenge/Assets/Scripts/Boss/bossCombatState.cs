using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCombatState : bossBaseState
{
    private float attackTimer;
    private float attackCooldown;
    private float S_AttackTimer;
    private float S_AttackCooldown;
    private bool isAttacking;
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        attackCooldown = boss.AttackTime;
        S_AttackCooldown = boss.S_AttackCooldown;
    }

    public override void UpdateState(bossStateManager boss)
    {
        checkSpecialAttack(boss);
        Attack();
        checkCooldown(boss);
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {

    }
    private void checkDistance(bossStateManager boss)
    {
        if(trnsfrm.position.x - playerPosition.position.x > boss.combatRange    ||
            trnsfrm.position.x - playerPosition.position.x < -boss.combatRange)
        {
            boss.SwitchState(boss.walkState);
        }
    }
    private void Attack()
    {
        if(!isAttacking)
        {
            checkDirection();
            isAttacking = true;
            animator.SetTrigger("Attack");
            attackTimer = Time.time;
        }
    }
    private void checkCooldown(bossStateManager boss)
    {
        if(Time.time - attackTimer > attackCooldown)
        {
            isAttacking = false;
            checkDistance(boss);
            checkDirection();
        }
    }
    private void checkSpecialAttack(bossStateManager boss)
    {
        if(Time.time - S_AttackTimer > S_AttackCooldown &&  !isAttacking)
        {
            S_AttackTimer = Time.time;
            boss.SwitchState(boss.S_AttackState);
        }
    }
}