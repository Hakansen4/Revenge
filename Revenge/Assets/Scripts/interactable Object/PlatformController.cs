using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private PlatformEffector2D PlatformEffector;
    private float waitTime;

    private void Start()
    {
        PlatformEffector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        CheckUp();
        CheckDown();
    }
    private void CheckUp()
    {
        if(Input.GetKey(KeyCode.W)    && waitTime <= 0)
        {
            PlatformEffector.rotationalOffset = 0.0f;
            waitTime = 0.5f;
            StartCoroutine(ResetPlatform());
        }
    }
    private void CheckDown()
    {
        if(Input.GetKey(KeyCode.S)  &&  waitTime <= 0)
        {
            PlatformEffector.rotationalOffset = 180.0f;
            waitTime = 0.5f;
            StartCoroutine(ResetPlatform());
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    private IEnumerator ResetPlatform()
    {
        yield return new WaitForSeconds(1.0f);
        PlatformEffector.rotationalOffset = 0.0f;
    }
}