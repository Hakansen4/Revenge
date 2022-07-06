using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class charMovingState : charBaseState
{
    private bool canJump;
    private float switchTimer;
    private charCombatController charCombat;
    public override void EnterState(charStateManger charachter)
    {
        addComponents(charachter);
        charCombat = charCombatController.instance;
        canJump = true;
        switchTimer = 0.5f;
    }

    public override void UpdateState(charStateManger charachter)
    {
        if(charachter.FLAG_MOVE)
        {
            MoveWorks(charachter);
        }
    }
    private void MoveWorks(charStateManger charachter)
    {
        jump();
        if (!charCombat.isAttacking || !canJump)
        {
            move(charachter);
            checkDash(charachter);
        }
    }

    public override void OnCollisionEnter2D(charStateManger charachter,Collision2D collisionInfo)
    {
        canJump = true;
    }

    private void jump()
    {
        #region PC_JUMP
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if(canJump)
        //    {
        //        animator.SetTrigger("isJumping");
        //        physic.AddForce(new Vector2(0, jumpPower));
        //        canJump = false;
        //    }
        //}
        #endregion
        #region MOBILE_JUMP
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                animator.SetTrigger("isJumping");
                physic.AddForce(new Vector2(0, jumpPower));
                canJump = false;
            }
        }
        #endregion
    }

    private void move(charStateManger charachter)
    {
        animator.SetBool("isRunning",true);
        //PC MOVEMENT
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //MOBILE MOVEMENT
        float horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        trnsfrm.position += new Vector3(horizontal * speed * Time.deltaTime,0,0);
        if(horizontal < 0)
            trnsfrm.localScale = new Vector3(-1,1,0);
        else if(horizontal > 0)
            trnsfrm.localScale = new Vector3(1,1,0);
        else
        {
            if(!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D) 
                &&  !Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    charachter.SwitchState(charachter.idleState);
                    animator.SetBool("isRunning",false);
                }
        }
    }
    private void checkDash(charStateManger charachter)
    {
        #region PC_CONTROL
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //    charachter.SwitchState(charachter.dashState);
        #endregion
        #region MOBILE_CONTROL
        if (CrossPlatformInputManager.GetButtonDown("Dash"))
            charachter.SwitchState(charachter.dashState);
        #endregion
    }
}