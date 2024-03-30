using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRange : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float moveSpeed;

    Rigidbody2D rigidbody2d;
    Animator anim;
    [SerializeField] HealthBoss healthBoss;
    public bool IsRun = false;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //if (!IsRun)
        //{
        //    return;
        //}
        
        //if (healthBoss.currentHealth <= 0)
        //{

        //    return;

        //}

        ////дистанция до игрока
        //float distToPlayer = Vector2.Distance(transform.position, player.position);

        //if (distToPlayer < agroRange)
        //{
        //    ChasePlayer();
        //}
        //else
        //{
        //    StopChasingPlayer();
        //}


    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rigidbody2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }

        anim.Play("Run");
    }

    internal bool PlayerOutOfRange()
    {
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > agroRange)
        {
            StopChasingPlayer();
            return true;
        }
        else
        {
            ChasePlayer();
            return false;
            
            
        }
        
        
    }

    public void StopChasingPlayer()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
        anim.Play("Idle");
    }

   



}




