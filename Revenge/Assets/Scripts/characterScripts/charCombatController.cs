using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCombatController : MonoBehaviour
{
    private enum AttackMode
{
    firstAttack,
    secondAttack,
    thirdAttack
}
    private Animator animator;
    [HideInInspector]public bool isAttacking;
    private AttackMode attackMode;
    private float restartTimer;
    private float attackAnimHittime = 0.4f;
    private float Damage;
    private charStateManger state;
    private float attackReloadTime = 0.50f;
    [Header("Attack Needs")]
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange;
    [SerializeField]private LayerMask enemyLayers;
    [SerializeField] private float restartTime;
    [Header("Damage Values")]
    [SerializeField]private int attack1Damage;[SerializeField]private int attack2Damage;[SerializeField]private int attack3Damage;
    private void Start() {
        animator = GetComponent<Animator>();
        isAttacking = false;
        attackMode = AttackMode.firstAttack;
        state = GetComponent<charStateManger>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0)  &&  !isAttacking    &&  state.currentState != state.deadState)
        {
            isAttacking = true;
            checkAttackMode();
            attack();
        }
    }
    private void attack()
    {
        //forAnimation
        switch(attackMode)
        {
            case AttackMode.firstAttack:
                animator.SetTrigger("attack1");
                Damage = attack1Damage;
                break;
            case AttackMode.secondAttack:
                animator.SetTrigger("attack2");
                Damage = attack2Damage;
                break;
            case AttackMode.thirdAttack:
                animator.SetTrigger("attack3");
                Damage = attack3Damage;
                break;
        }
        //attackWorks
        restartTimer = Time.time;
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            StartCoroutine(attackWorks(enemy));
        }
        StartCoroutine(nameof(reloadAttack));
    }

    private void checkAttackMode()
    {
        if(attackMode != AttackMode.thirdAttack)
        {
            if(Time.time-restartTimer   <  restartTime)
                attackMode++;
            else
                attackMode = AttackMode.firstAttack;
        }
        else
        {
            attackMode = AttackMode.firstAttack;
        }
    }

    private IEnumerator reloadAttack()
    {
        yield return new WaitForSeconds(attackReloadTime);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);    
    }

    private IEnumerator attackWorks(Collider2D enemy)
    {
            yield return new WaitForSeconds(attackAnimHittime);
            e_0stateManager enemyState = enemy.GetComponentInParent<e_0stateManager>();
            e_0healthController healthEnemy = enemy.GetComponentInParent<e_0healthController>();
            if(enemyState.combatState.isHeavy)
            {
                healthEnemy.increaseHealth();
                if(!enemyState.combatState.isAttacking)
                {
                    if(gameObject.transform.position.x > enemy.GetComponent<Transform>().position.x)
                        enemy.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-1,1)*100);
                    else
                        enemy.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(1,1)*100);
                    if(!healthEnemy.isDead())
                        enemyState.SwitchState(enemyState.hittedState);
                }
            }
            else
            {
                healthEnemy.increaseHealth();
                if(!healthEnemy.isDead())
                {
                    if(gameObject.transform.position.x > enemy.GetComponent<Transform>().position.x)
                        enemy.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-1,1)*100);
                    else
                        enemy.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(1,1)*100);
                 
                        enemyState.SwitchState(enemyState.hittedState);
                }
            }
    }
}