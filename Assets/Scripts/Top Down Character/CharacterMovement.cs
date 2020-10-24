using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Joystick joystick;
    public float speed = 5f;
    public Animator animator;
    Rigidbody2D rb; // Character need to add rigid body, make 0 gravity scale and constrain -> check rotation z
    Vector2 movement;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime );
        animator.SetFloat("speed",Mathf.Abs( joystick.Horizontal));
        if(movement.x<0)
        transform.localScale = new Vector3(-1f, 1f, 1f);
        else
            transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
