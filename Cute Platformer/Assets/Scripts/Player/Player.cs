using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    public Animator anim;

    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
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
            anim.SetInteger("Transition", 1);
            
            transform.eulerAngles = new Vector2(0, 0);
        }
        
        if(xInput < 0)
        {
            anim.SetInteger("Transition", 1);

            transform.eulerAngles = new Vector2(0, 180);
        }

        if(xInput == 0)
        {
            anim.SetInteger("Transition", 0);
        }
    }
}
