using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    public Animator anim;
    public Transform groundCheck;

    public bool isJumping;

    public float speed;
    public float jumpForce;
    public float jumpCount;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(xInput * speed, rig.velocity.y);


        if (xInput > 0)
        {
            if (isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            
            
            transform.eulerAngles = new Vector2(0, 0);
        }
        
        if(xInput < 0)
        {
            if (isJumping)
            {
                anim.SetInteger("Transition", 1);
            }

            transform.eulerAngles = new Vector2(0, 180);
        }

        if(xInput == 0)
        {
            if (isJumping)
            {
                anim.SetInteger("Transition", 0);
            }
            
        }
    }

    void Jump()
    {
        isJumping = GetComponentInChildren<GroundCheck>().IsJumping;
        if (Input.GetButtonDown("Jump") && isJumping)
        {
            anim.SetInteger("Transition",2);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }
}
