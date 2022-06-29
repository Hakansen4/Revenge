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

    public static charCombatController instance;
    [SerializeField] private Player _playerData;
   
    private Animator animator;
    [HideInInspector]public bool isAttacking;

    private AttackMode attackMode;
    private PlayerSoundManager Sounds;
    private float restartTimer;
    private float attackAnimHittime = 0.4f;
    private float Damage;
    private charStateManger state;
    private float attackReloadTime = 0.50f;
    [SerializeField]private Transform attackPoint;
    private float attackRange;
    private LayerMask enemyLayers;
    private float restartTime;
    public int attack1Damage;private int attack2Damage;private int attack3Damage;
    private void Awake()
    {
        instance = this;
        attackRange = _playerData.AttackRange;
        enemyLayers = _playerData.enemyLayers;
        restartTime = _playerData.attackRestartTime;
        attack1Damage = _playerData.FirstAttackDamge;
        attack2Damage = _playerData.SeconAttackdDamge;
        attack3Damage = _playerData.ThirdAttackDamge;
    }
    private void Start() {
        Sounds = PlayerSoundManager.instance;
        animator = GetComponent<Animator>();
        isAttacking = false;
        attackMode = AttackMode.firstAttack;
        state = charStateManger.instance;
    }
    private void Update() {
        if(Input.GetMouseButtonDown(0)  &&  !isAttacking    &&  state.currentState != state.deadState
            &&  state.currentState != state.restState)
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
        if (hitEnemies.Length == 0)
            Sounds.Play(PlayerAudio.Attack);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.CompareTag("Enemy"))
            {
                StartCoroutine(attackWorksE_0(enemy));
            }
            else if(enemy.CompareTag("Boss"))
            {
                StartCoroutine(attackWorksBoss(enemy));
            }
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

    private IEnumerator attackWorksE_0(Collider2D enemy)
    {
        e_0stateManager enemyState = enemy.GetComponentInParent<e_0stateManager>();
        e_0healthController healthEnemy = enemy.GetComponentInParent<e_0healthController>();
        if (!healthEnemy.isDead())
            Sounds.Play(PlayerAudio.HitEnemy);
        yield return new WaitForSeconds(attackAnimHittime);
        if (!healthEnemy.isDead())
            BloodEffectController.Play();
        healthEnemy.increaseHealth(Damage);
        if (enemyState.combatState.isHeavy)
        {
            if (!enemyState.combatState.isAttacking)
            {
                if (!healthEnemy.isDead())
                    enemyState.SwitchState(enemyState.hittedState);
            }
        }
        else
        {
            if (!healthEnemy.isDead()) 
            {
                enemyState.SwitchState(enemyState.hittedState);
            }
        }
    }

    private IEnumerator attackWorksBoss(Collider2D enemy)
    {
            yield return new WaitForSeconds(attackAnimHittime);
            bossStateManager bossState = enemy.GetComponentInParent<bossStateManager>();
            bossHealthController healthBoss = enemy.GetComponentInParent<bossHealthController>();
            healthBoss.increaseHealth();
    }
    public float getDamage()
    {
        return attack1Damage;
    }
    public void levelUpDamage(int damage)
    {
        Debug.Log("Eski Damage = " + attack1Damage);
        attack1Damage += damage;
        attack2Damage += damage;
        attack3Damage += damage;
        Debug.Log("Yeni Damage = " + attack1Damage);
    }
}