using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Player")]
public class Player : ScriptableObject
{
    public float Health;
    public int PotionCount;
    public float AttackRange;
    public float attackRestartTime;
    public int FirstAttackDamge;
    public int SeconAttackdDamge;
    public int ThirdAttackDamge;
    public LayerMask enemyLayers;
}
