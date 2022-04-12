using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_0hittedState : e_0baseState
{
    private Animator anim;
    private float timer;
    private float hitAnimTime;
    public override void EnterState(e_0stateManager enemy)
    {
        anim = enemy.GetComponent<Animator>();
        anim.SetBool("isWalking",true);
        anim.SetTrigger("Hit");
        hitAnimTime = enemy.hitAnimTime;
        timer = Time.time;
    }

    public override void UpdateState(e_0stateManager enemy)
    {
        checkTimer(enemy);
    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
    private void checkTimer(e_0stateManager enemy)
    {
        if(Time.time - timer > hitAnimTime)
        {
            enemy.SwitchState(enemy.chaseState);
        }
    }
}