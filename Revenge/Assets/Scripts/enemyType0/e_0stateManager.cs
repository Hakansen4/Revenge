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
    [SerializeField]private Enemies enemyType;

    [HideInInspector] public Vector3 startingPosition; 
    [HideInInspector] public float attackAnimLong;
    [HideInInspector] public float hitAnimTime;
    [HideInInspector] public float attackRange;
    [HideInInspector] public bool isHeavyEnemy;
    [HideInInspector] public bool isRangeEnemy;
    [HideInInspector]public bool isGoingLeft = false;
    
    #region States
    public e_0baseState currentState;
    public e_0patrollingState patrolState = new e_0patrollingState();
    public e_0chaseState chaseState = new e_0chaseState();
    public e_0combatState combatState = new e_0combatState();
    public e_0hittedState hittedState = new e_0hittedState();
    public e_0deadState deadState = new e_0deadState();
    #endregion

    private void Awake()
    {
        attackAnimLong = enemyType.attackAnimLong;
        hitAnimTime = enemyType.hitAnimTime;
        attackRange = enemyType.attackRange;
        isHeavyEnemy = enemyType.isHeavyEnemy;
        isRangeEnemy = enemyType.isRangeEnemy;
    }
    void Start()
    {
        leftBorder = patrolLeft.position.x;
        startingPosition = patrolLeft.position;
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
