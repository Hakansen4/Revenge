using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDashMove : MonoBehaviour
{
    private Transform playerPos;
    private Transform bossPos;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossPos = GetComponentInParent<Transform>();
    }

    public void dashMove()
    {
        GetComponentInParent<bossStateManager>().currentState.canDash = true;
    }
}
