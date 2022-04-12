using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_0deadState : e_0baseState
{
    private Animator anim;
    public override void EnterState(e_0stateManager enemy)
    {
        anim = enemy.GetComponent<Animator>();
        anim.SetTrigger("Dead");
    }

    public override void UpdateState(e_0stateManager enemy)
    {

    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
}