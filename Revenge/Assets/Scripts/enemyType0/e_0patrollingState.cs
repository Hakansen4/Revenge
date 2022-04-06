using UnityEngine;

public class e_0patrollingState : e_0baseState
{
    private Transform trnsfrm;
    private e_0triggerArea trigger;
    public override void EnterState(e_0stateManager enemy)
    {
        trnsfrm = enemy.GetComponent<Transform>();
        trigger = enemy.triggerGO.GetComponent<e_0triggerArea>(); 
        checkDirection(enemy);
    }

    public override void UpdateState(e_0stateManager enemy)
    {
        checkDirection(enemy);
        patrolling(enemy);
        checkPlayerPosition(enemy);
    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
    private void patrolling(e_0stateManager enemy)
    {
        if(enemy.isGoingLeft)
        {
            trnsfrm.position -= new Vector3(speed * Time.deltaTime,0,0);
        }
        else 
        {
            trnsfrm.position += new Vector3(speed * Time.deltaTime,0,0);
        }
    }
    private void checkDirection(e_0stateManager enemy)
    {
        if(trnsfrm.position.x > enemy.rightBorder   &&  !enemy.isGoingLeft)
        {
            trnsfrm.localScale = new Vector3(-1,1,1);
            enemy.isGoingLeft = true;
            trnsfrm.position -= Vector3.right;
        }
        else if(trnsfrm.position.x < enemy.leftBorder   &&  enemy.isGoingLeft)
        {
            enemy.isGoingLeft = false;
            trnsfrm.localScale = new Vector3(1,1,1);
            trnsfrm.position += Vector3.right;
        }
    }

    private void checkPlayerPosition(e_0stateManager enemy)
    {
        if(trigger.chaseStart)
            enemy.SwitchState(enemy.chaseState);
    }
}
