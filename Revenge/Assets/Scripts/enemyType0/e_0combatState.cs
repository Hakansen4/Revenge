using UnityEngine;

public class e_0combatState : e_0baseState
{
    private float cdTimer = 0;
    private float cooldown = 1;
    private float rangeColldown = 2;
    private float animTimer;
    private float animLong;
    private Animator anim;
    public bool isAttacking;
    public bool isHeavy;
    private bool animFinished;
    private Transform playerPosition;
    public override void EnterState(e_0stateManager enemy)
    {
        animLong = enemy.attackAnimLong;
        anim = enemy.GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isAttacking = false;
        isHeavy = enemy.isHeavyEnemy;
        animFinished = true;
        anim.SetBool("isWalking",false);
        if(enemy.isRangeEnemy)
            cooldown = rangeColldown;
    }

    public override void UpdateState(e_0stateManager enemy)
    {
        attack(enemy);
        checkAnimFinished(enemy);
        if(enemy.isRangeEnemy)
            checkPosition(enemy);
    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
    public void checkPosition(e_0stateManager enemy)
    {
        if(enemy.transform.position.x - playerPosition.position.x <= enemy.attackRange &&
            enemy.transform.position.x - playerPosition.position.x >= -enemy.attackRange)
            {
                if(playerPosition.position.x - enemy.transform.position.x > 1  &&  enemy.isGoingLeft)
                {
                    enemy.transform.localScale = new Vector3(1,1,1);
                    enemy.isGoingLeft = false;
                    enemy.transform.position += Vector3.right;
                    return;
                }
                else if(!enemy.isGoingLeft  &&  playerPosition.position.x - enemy.transform.position.x < -1)
                {
                    enemy.transform.localScale = new Vector3(-1,1,1);
                    enemy.isGoingLeft = true;
                    enemy.transform.position -= Vector3.right;
                    return;
                }
            }
        else
        {
            cdTimer = Time.time;
            anim.SetBool("isWalking",true);
            enemy.SwitchState(enemy.chaseState);
        }
    }
    private void attack(e_0stateManager enemy)
    {
        if(Time.time - cdTimer > cooldown   &&  !isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("Attack");
            animTimer = Time.time + animLong;
            animFinished = false;
        }
    }
    private void checkAnimFinished(e_0stateManager enemy)
    {
        if(Time.time - animTimer > animLong &&  !animFinished)
        {
            animFinished = true;
            cdTimer = Time.time;
            isAttacking = false;
            checkPosition(enemy);
        }
    }
}