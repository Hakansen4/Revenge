using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class bossBaseState
{
    public Rigidbody2D physic;
    public Transform trnsfrm;
    public Animator animator;
    public Transform playerPosition;
    public bool canDash = false;
    public bool goingLeft = true;
    public abstract void EnterState(bossStateManager boss);

    public abstract void UpdateState(bossStateManager boss);

    public abstract void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo);

    public void addComponents(bossStateManager boss)
    {
        physic = boss.GetComponent<Rigidbody2D>();
        trnsfrm = boss.GetComponent<Transform>();
        animator = boss.GetComponentInChildren<Animator>();
        playerPosition = boss.playerPos;
    }
    public void checkDirection()
    {
        if(playerPosition.position.x > trnsfrm.position.x   &&  !goingLeft)
        {
            trnsfrm.localScale = new Vector3(1,1,1);
            trnsfrm.position -= Vector3.right/2;
            goingLeft = true;
        }
        else if(playerPosition.position.x < trnsfrm.position.x  &&  goingLeft)
        {
            trnsfrm.localScale = new Vector3(-1,1,1);
            trnsfrm.position += Vector3.right/2;
            goingLeft = false;
        }
    }
    public void dashMove()
    {
        if(canDash)
        {
            if(playerPosition.position.x > trnsfrm.position.x)
            {
                trnsfrm.position = new Vector3(playerPosition.position.x -2.5f,trnsfrm.position.y,trnsfrm.position.z);
            }
            else
            {
                trnsfrm.position = new Vector3(playerPosition.position.x +2.5f,trnsfrm.position.y,trnsfrm.position.z);
            }
            canDash = false;
        }
    }
}