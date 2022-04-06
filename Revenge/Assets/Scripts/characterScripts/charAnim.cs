using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charAnim : MonoBehaviour
{
    private Animator animator;
    void Awake() {
        animator = GetComponent<Animator>();        
    }
}
