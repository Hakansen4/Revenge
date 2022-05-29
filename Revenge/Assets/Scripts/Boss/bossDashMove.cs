using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDashMove : MonoBehaviour
{
    public void dashMove()
    {
        GetComponentInParent<bossStateManager>().currentState.canDash = true;
    }
}
