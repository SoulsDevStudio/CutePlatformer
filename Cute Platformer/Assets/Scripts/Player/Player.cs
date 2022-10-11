using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    public Animator anim;
    public Transform groundCheck;

    public bool isAttack;
    public bool isJumping;

    public float speed;
    public float jumpForce;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Attack();
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
            if (isJumping && !isAttack)
            {
                anim.SetInteger("Transition", 1);
            }
            
            
            transform.eulerAngles = new Vector2(0, 0);
        }
        
        if(xInput < 0)
        {
            if (isJumping && !isAttack)
            {
                anim.SetInteger("Transition", 1);
            }

            transform.eulerAngles = new Vector2(0, 180);
        }

        if(xInput == 0)
        {
            if (isJumping && !isAttack)
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

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttack = true;
            anim.SetInteger("Transition", 3);

            StartCoroutine(OnAttack());
        }
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.53f);
        isAttack = false;
    }

}
