using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothValue;
    private void followPlayer()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothValue * Time.deltaTime);
        transform.position = smoothPosition;
    }
    void LateUpdate()
    {
        followPlayer();
    }
}
