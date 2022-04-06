using UnityEngine;

public abstract class charBaseState 
{
    public float speed = 6;
    public float jumpPower = 200;
    public Rigidbody2D physic;
    public Transform trnsfrm;
    public Animator animator;
    public abstract void EnterState(charStateManger charachter);

    public abstract void UpdateState(charStateManger charachter);

    public abstract void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo);

    public void addComponents(charStateManger charachter)
    {
        physic = charachter.GetComponent<Rigidbody2D>();
        trnsfrm = charachter.GetComponent<Transform>();
        animator = charachter.GetComponent<Animator>();
    }

}
