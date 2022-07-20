using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    //Sag = -0.5
    public float DestroyTime = 0.3f;
    private Vector3 offset;
    private bool isRight;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        checkDireciton();
        transform.localPosition += offset;
    }

    private void checkDireciton()
    {
        if (isRight)
            offset = new Vector3(-0.5f, 1, 0);
        else
            offset = new Vector3(0.5f, 1, 0);
    }

    public void SetDirection(bool _IsRight)
    {
        if (_IsRight)
            isRight = true;
        else
            isRight = false;
    }
}
