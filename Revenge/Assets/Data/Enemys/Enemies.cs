using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type",menuName ="Enemy Type")]
public class Enemies : ScriptableObject
{
    public bool isRangeEnemy;
    public bool isHeavyEnemy;
    public float enemyHealth;
    public float enemySoulCount;
    public float attackRange;
    public float hitAnimTime;
    public float attackAnimLong;
}
