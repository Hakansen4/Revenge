using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BloodEffectController : MonoBehaviour 
{
    public static BloodEffectController instance;

    public GameObject HitEffect;

    private void Awake()
    {
        instance = this;
    }
    public  void Play()
    {
        Instantiate(HitEffect, transform.position, Quaternion.identity);
    }
}
