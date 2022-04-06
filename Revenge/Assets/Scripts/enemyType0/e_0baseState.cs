using UnityEngine;

public abstract class e_0baseState 
{
    public float speed = 2.0f;
    public abstract void EnterState(e_0stateManager enemy);

    public abstract void UpdateState(e_0stateManager enemy);

    public abstract void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo);
}