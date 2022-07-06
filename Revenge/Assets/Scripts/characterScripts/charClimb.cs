using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class charClimb : MonoBehaviour
{
    private float vertical;
    private float speed = 4f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private void Update()
    {
        //PC_CONTROL
        //vertical = Input.GetAxis("Vertical");
        //MOBILE_CONTROL
        vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            anim.SetBool("ClimbStop", false);
            anim.SetBool("Climb", true);
            isClimbing = true;
        }
        else if (isClimbing && vertical == 0)
        {
            anim.SetBool("ClimbStop", true);
        }
    }
    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("Climb", false);
        }
    }
}
