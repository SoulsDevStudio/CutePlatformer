using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    float attackCount;

    public Animator anim;
    public Transform groundCheck;
    public Transform hitPoint;
    public LayerMask layer;

    public bool isAttack;
    public bool isJumping;

    public float speed;
    public float jumpForce;
    public float radius;
    public float attackCoudown;
    public float jumpCount;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        attackCount += Time.deltaTime;
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
        if (Input.GetButtonDown("Fire1") && attackCount >= attackCoudown)
        {
            Collider2D hit = Physics2D.OverlapCircle(hitPoint.position, radius,layer);

            isAttack = true;
            anim.SetInteger("Transition", 3);

            if(hit != null)
            {
                hit.GetComponent<SkeletonAxe>().Hit();
            }
            attackCount = 0;

            StartCoroutine(OnAttack());
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPoint.position, radius);   
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.53f);
        isAttack = false;
    }

}
