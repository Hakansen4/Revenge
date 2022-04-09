using UnityEngine;

public class charIdleState : charBaseState
{
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
    }

    public override void UpdateState(charStateManger charachter)
    {
        checkInput(charachter);
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {

    }
    public void checkInput(charStateManger charachter)
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal != 0)
            charachter.SwitchState(charachter.movingState);
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            charachter.SwitchState(charachter.jumpState);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            charachter.SwitchState(charachter.dashState);
        }
    }
}
