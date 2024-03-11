using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEnge;
    [SerializeField] private Transform rightEnge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    BossHealth bosshealth;
   
    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingleft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private enum STATES
    {
        LIVE = 1,
        DEAD = 0
    }

    private STATES state = STATES.LIVE;


    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }

    private void Update()
    {
        if (state == STATES.LIVE)
        {
            if (movingleft)
            {
                if (enemy.position.x >= leftEnge.position.x)
                    MoveInDirection(-1);
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x <= rightEnge.position.x)
                    MoveInDirection(1);
                else
                {
                    DirectionChange();
                }
            }
        } 
        
        
        
    }

    public void DirectionChange()
    {
        anim.SetBool("Moving", false);
           idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingleft = !movingleft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    void Disable()
    {
        if (bosshealth.health <= 10)
        {
            this.enabled = false;
        }

        

    }
}


