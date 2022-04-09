using UnityEngine;

public class e_0chaseState : e_0baseState
{
    private Transform playerPosition;
    private e_0triggerArea trigger;
    public override void EnterState(e_0stateManager enemy)
    {
        trigger = enemy.triggerGO.GetComponent<e_0triggerArea>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        checkDirection(enemy);
    }

    public override void UpdateState(e_0stateManager enemy)
    {
        chase(enemy);
        checkDistance(enemy);
        checkDirection(enemy);
    }

    public override void OnCollisionEnter2D(e_0stateManager enemy,Collision2D collisionInfo)
    {

    }
    private void chase(e_0stateManager enemy)
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,playerPosition.position,speed*Time.deltaTime);
    }

    private void checkDistance(e_0stateManager enemy)
    {
        if(enemy.transform.position.x - playerPosition.position.x <= 1 &&
            enemy.transform.position.x - playerPosition.position.x >= -1)
            {
                enemy.SwitchState(enemy.combatState);
            }
        else if(!trigger.chaseStart)
        {
            enemy.SwitchState(enemy.patrolState);
        }
    }

    private void checkDirection(e_0stateManager enemy)
    {
        if(enemy.isGoingLeft)
        {
            if(playerPosition.position.x > enemy.transform.position.x)
            {
                enemy.isGoingLeft = false;
                enemy.transform.localScale = new Vector3(1,1,1);
                enemy.transform.position += Vector3.right;
            }
        }
        else if(!enemy.isGoingLeft)
        {
            if(playerPosition.position.x < enemy.transform.position.x)
            {
                enemy.isGoingLeft = true;
                enemy.transform.localScale = new Vector3(-1,1,1);
                enemy.transform.position -= Vector3.right;
            }
        }
    }
}