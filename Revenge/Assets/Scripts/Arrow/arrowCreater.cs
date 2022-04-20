using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCreater : MonoBehaviour
{
    public GameObject arrow;
    public Transform position;
    private bool isGoingLeft;
    public void createArrow()
    {
        isGoingLeft = GetComponent<e_0stateManager>().isGoingLeft;
        GameObject arrowObject;
        arrowObject =  Instantiate(arrow,position.position,Quaternion.identity);
        arrowObject.GetComponent<arrowController>().isGoingLeft = isGoingLeft;
    }
}
