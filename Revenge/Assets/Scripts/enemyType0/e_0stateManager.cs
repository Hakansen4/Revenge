using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_0stateManager : MonoBehaviour
{
    #region Patrol Sinirlari
    [SerializeField]private Transform patrolRight;
    [SerializeField]private Transform patrolLeft;
    [HideInInspector]public float rightBorder;
    [HideInInspector]public float leftBorder;
    #endregion
    public GameObject triggerGO;
    public bool isHeavyEnemy;
    public bool isGoingLeft = false;
    public e_0baseState currentState;
    public e_0patrollingState patrolState = new e_0patrollingState();
    public e_0chaseState chaseState = new e_0chaseState();
    public e_0combatState combatState = new e_0combatState();

    void Start()
    {
        leftBorder = patrolLeft.position.x;
        rightBorder = patrolRight.position.x;
        currentState = patrolState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        currentState.OnCollisionEnter2D(this,collisionInfo);
    }

    public void SwitchState(e_0baseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
