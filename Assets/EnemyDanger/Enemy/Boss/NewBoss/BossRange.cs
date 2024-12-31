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
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    
     public void ChasePlayer()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (transform.position.x < player.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector2(-1, 1);
        }




        //Vector2 movement;
        //if (transform.position.x < player.position.x)
        //{
        //    movement = new Vector2((-1) * moveSpeed, rigidbody2d.velocity.y);
        //    transform.localScale = new Vector2(1, 1);
        //}
        //else if (transform.position.x > player.position.x)
        //{
        //    movement = new Vector2((1) * moveSpeed, rigidbody2d.velocity.y);
        //    transform.localScale = new Vector2(-1, 1);
        //}
        //else
        //{
        //    movement = new Vector2();

        //}
        //Debug.Log(movement);
        //rigidbody2d.velocity = movement;


    }

    internal bool PlayerOutOfRange()
    {
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > agroRange)
        {
           
            return true;
        }
        else
        {
            
            return false;
            
            
        }
        
        
    }

    public void StopChasingPlayer()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
        anim.Play("Idle");
    }

   



}




