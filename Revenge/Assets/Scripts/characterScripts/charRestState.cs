using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charRestState : charBaseState
{
    charHealthController charHealth;
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        charHealth = charachter.gameObject.GetComponent<charHealthController>();
        charHealth.rest();
        animator.SetTrigger("Rest");
    }

    public override void OnCollisionEnter2D(charStateManger charachter, Collision2D collisionInfo)
    {
    }

    public override void UpdateState(charStateManger charachter)
    {
    }
}
