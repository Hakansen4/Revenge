using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour
{
    public static checkpointController instance;

    private Vector3 checkpointPosition;
    private void Awake()
    {
        instance = this;
    }

    public void setCheckpointPosition(Vector3 newPos)
    {
        checkpointPosition = newPos;
    }

    public Vector3 getCheckpointPosition()
    {
        return checkpointPosition;
    }
}