using UnityEngine;

public class e_0combatState : e_0baseState
{
    private float cdTimer;
    private float cooldown = 1;
    private float animTimer;
    private float animLong = 1f;
    private Animator anim;
    private bool isAttacking;
    private bool isHeavy;
    private bool animFinished;
    private Transform playerPosition;
    public override void EnterState(e_0stateManager enemy)
    {
        cdTimer = Time.time - cooldown;
        anim = enemy.GetComponent<Animator>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isAttacking = false;
        isHeavy = enemy.isHeavyEnemy;
        animFinished = true;
        anim.SetBool("isWalking",false);
    }

    public override void UpdateState(e_0stateManager enemy)
    {
        attack(enemy);
        checkAnimFinished(enemy);
    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
    public void checkPosition(e_0stateManager enemy)
    {
        if(enemy.transform.position.x - playerPosition.position.x <= 1 &&
            enemy.transform.position.x - playerPosition.position.x >= -1)
            {
                if(playerPosition.position.x > enemy.transform.position.x   &&  enemy.isGoingLeft)
                {
                    enemy.transform.localScale = new Vector3(1,1,1);
                    enemy.transform.position += Vector3.right;
                    return;
                }
                else if(!enemy.isGoingLeft  &&  playerPosition.position.x < enemy.transform.position.x)
                {
                    enemy.transform.localScale = new Vector3(-1,1,1);
                    enemy.transform.position -= Vector3.right;
                    return;
                }
            }
        else
        {
            enemy.SwitchState(enemy.chaseState);
            anim.SetBool("isWalking",true);
        }
    }
    private void attack(e_0stateManager enemy)
    {
        if(Time.time - cdTimer > cooldown   &&  !isAttacking)
        {
            isAttacking = true;
            if(isHeavy)
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