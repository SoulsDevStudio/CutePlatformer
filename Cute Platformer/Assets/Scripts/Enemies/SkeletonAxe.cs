using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAxe : Enemy
{
    Rigidbody2D rig;

    public float distancePointA;
    public float distancePointB;

    public Transform pointA;
    public Transform pointB;

    public bool patrolling;
    public bool isRigth;

    public float speedPatrolling;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(patrolling)
        {
            Patrolling();
        }
    }

    void Patrolling()
    {
        anim.SetInteger("Transition", 1);
        
        if(isRigth)
        {
            distancePointB = Vector2.Distance(transform.position, pointB.position);
            transform.eulerAngles = new Vector2(0, 0);
            if(distancePointB < 1f)
            {
                Debug.Log("To aqui");
                isRigth = false;
                
            }
            rig.velocity = new Vector2(speedPatrolling, rig.velocity.y);
        }
        else
        {
            distancePointA = Vector2.Distance(transform.position, pointA.position);
            transform.eulerAngles = new Vector2(0, 180);
            if (distancePointA < 1f)
            {
                Debug.Log("To aqui");
                isRigth = true;
            }
            rig.velocity = new Vector2(-speedPatrolling, rig.velocity.y);
        }

    }
}
