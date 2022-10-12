using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    public float health;
    public float damage;

    void Start()
    {
    }

    void Update()
    {

    }

    public virtual void Hit()
    {
        health -= 1;

        if (health >= 1)
        {
            anim.SetTrigger("isHit");
        }
        else
        {
            Death();
        }
        
    }

    void Death()
    {
        anim.SetTrigger("Dead");
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
