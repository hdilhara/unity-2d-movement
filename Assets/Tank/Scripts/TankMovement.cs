using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public Joystick joystick;
    public float speed = 5f ;
    public Animator trackAnimator;
    public Animator trackAnimator1;
    public GameObject tankExplosionVFX;
    public string exposionHappenTagName = "bullet";



    Rigidbody2D rb; // Character need to add rigid body, make 0 gravity scale and constrain -> check rotation z

    Vector2 movement;
    float angle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {// this use get input
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if(Mathf.Abs(movement.x)  > 0.2 || Mathf.Abs(movement.y) > 0.2 )
            angle = Mathf.Atan2(movement.y,movement.x)*Mathf.Rad2Deg -90f;
    }

    //Same as update but work in relavent to time(1s) not frames
    // by default this will call 50 times per second
    private void FixedUpdate()
    {// this use movement
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.rotation = angle;
        if (movement.sqrMagnitude > 0)
        {
            trackAnimator.SetBool("isTankMoving", true);
            trackAnimator1.SetBool("isTankMoving", true);
        }
        else
        {
            trackAnimator.SetBool("isTankMoving", false);
            trackAnimator1.SetBool("isTankMoving", false);
        }
            
    }

    public bool isStopped()
    {
        if ((joystick.Vertical == 0f) && (joystick.Horizontal == 0f))
            return true;
        else
            return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag.Equals(exposionHappenTagName) == true)
            {
                Vector3 pos = transform.position;
                pos.z = -4.3f;
                Destroy(Instantiate(tankExplosionVFX, pos, Quaternion.identity), 0.5f);
                Destroy(gameObject, 0.5f);
            }
    }

}
