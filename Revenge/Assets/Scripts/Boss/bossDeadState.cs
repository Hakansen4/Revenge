using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDeadState : bossBaseState
{
    private float timer;
    public override void EnterState(bossStateManager boss)
    {
        addComponents(boss);
        animator.SetTrigger("Dead");
        timer = Time.time;
    }

    public override void UpdateState(bossStateManager boss)
    {
        checkTimer();
    }

    public override void OnCollisionEnter2D(bossStateManager boss,Collision2D collisionInfo)
    {

    }
    private void checkTimer()
    {
        if(Time.time - timer > 3)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
