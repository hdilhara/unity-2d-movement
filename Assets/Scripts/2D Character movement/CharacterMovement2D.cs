using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{

    public CharacterController2D controller;
    public Joystick joystick;
    public float runSpeed= 15f;
    public float fireGap =0.5f; 
    public Animator animator;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false; // for jump work fine  increece gravity scale

    //for make smoothness make player and road( holders ) have slippy metirial
    //bounce = 0 and friction 0

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal;
        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
        verticalMove = joystick.Vertical;
        if(verticalMove > 0.7)
        {
            jump = true;
           animator.SetBool("jump",true);
        }
    }

    private void FixedUpdate()
    {
        //args => x axis move / crouch / jump
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void onLandingAfterJump()
    {
        animator.SetBool("jump", false);
    }

    public void onFireButtonPress()
    {
        animator.SetBool("fire", true);
        Invoke("fireOver", fireGap);
    }

    void fireOver()
    {
        animator.SetBool("fire",false);
    }


}
