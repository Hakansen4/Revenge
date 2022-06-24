using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BloodEffectController : MonoBehaviour 
{
    public static BloodEffectController instance;

    private static Animator anim;

    private void Awake()
    {
        instance = this;
        anim = GetComponentInChildren<Animator>();
    }
    public static void Play()
    {
        anim.SetTrigger("Play");
    }
}
