using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
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
        #region PC_CONTROL
        //if (Input.GetKey(KeyCode.W)    && waitTime <= 0)
        //{
        //    PlatformEffector.rotationalOffset = 0.0f;
        //    waitTime = 0.5f;
        //}
        #endregion
        #region MOBILE_CONTROL
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0 && waitTime <= 0)
        {
            PlatformEffector.rotationalOffset = 0.0f;
            waitTime = 0.5f;
        }
        #endregion
    }
    private void OnCollisionExit(Collision collision)
    {
        ResetPlatform();
    }
    private void CheckDown()
    {
        #region PC_CONTROL
        //if(Input.GetKey(KeyCode.S)  &&  waitTime <= 0)
        //{
        //    PlatformEffector.rotationalOffset = 180.0f;
        //    waitTime = 0.5f;
        //    StartCoroutine(ResetPlatform());
        //}
        //else
        //{
        //    waitTime -= Time.deltaTime;
        //}
        #endregion
        #region MOBILE_CONTROL
        if (CrossPlatformInputManager.GetAxis("Vertical") < 0 && waitTime <= 0)
        {
            PlatformEffector.rotationalOffset = 180.0f;
            waitTime = 0.5f;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
        #endregion
    }
    private void ResetPlatform()
    {
        PlatformEffector.rotationalOffset = 0.0f;
    }
}