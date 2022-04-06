using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_0triggerArea : MonoBehaviour
{
    public bool chaseStart;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chaseStart = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chaseStart = false;
        }
    }
}
