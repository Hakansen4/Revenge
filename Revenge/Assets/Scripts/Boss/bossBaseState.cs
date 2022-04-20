using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class bossBaseState
{
    public abstract void EnterState(bossStateManager boss);

    public abstract void UpdateState(bossStateManager boss);

    public abstract void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo);
}