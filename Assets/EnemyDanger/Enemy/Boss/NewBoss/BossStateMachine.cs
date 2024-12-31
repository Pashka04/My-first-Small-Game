using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public enum BossState
    {
        Idle,
        Attack,
        Run,
        Hurt,
        Die
    }

    private BossState currentState;

    private Animator anim;
    AttackBoss attackBoss;
    HealthBoss healthBoss;
    BossRange bossRange;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        attackBoss = GetComponent<AttackBoss>();
        healthBoss = GetComponent<HealthBoss>();
        bossRange = GetComponent<BossRange>();
       
    }

    
    
    void Start()
    {
        TransitionToState(BossState.Idle);
    }

    void Update()
    {
        Debug.Log(currentState.ToString());

        switch (currentState)
        {
            case BossState.Idle:
                bossRange.StopChasingPlayer();

                if (attackBoss.PlayerInSight())
                {
                    TransitionToState(BossState.Attack);
                }
               
                else if (!bossRange.PlayerOutOfRange())
                {
                    TransitionToState(BossState.Run);
                }
               
                else if (healthBoss.currentHealth <= 0)
               {
                    TransitionToState(BossState.Die);
               }
                else if (healthBoss.isTakeDamage)
                {

                    TransitionToState(BossState.Hurt);

                }
                    break;

            case BossState.Attack:
                anim.SetTrigger("Attack");
                if (!attackBoss.PlayerInSight())
                {
                    TransitionToState(BossState.Idle);
                }
               else if (healthBoss.currentHealth <= 0)
                {
                    TransitionToState(BossState.Die);
                }
                else if (healthBoss.isTakeDamage)
                {
                    TransitionToState(BossState.Hurt);
                }
                    break;

            case BossState.Run:
                bossRange.IsRun = true;
                bossRange.ChasePlayer();
                anim.Play("Run");
                if (bossRange.PlayerOutOfRange())
                {
                    TransitionToState(BossState.Idle);
                }
               else if (attackBoss.PlayerInSight())
                {
                    TransitionToState(BossState.Attack);
                }
               else if (healthBoss.currentHealth <= 0)
                {
                    TransitionToState(BossState.Die);
                }
                else if (healthBoss.isTakeDamage)
                {
                    TransitionToState(BossState.Hurt);
                }
                

                break;

            case BossState.Hurt:
              
                if(healthBoss.isTakeDamage == false)
                {
                    TransitionToState(BossState.Idle);
                }
                if(healthBoss.currentHealth <= 0)
                {
                    TransitionToState(BossState.Die);
                }

                break;

            case BossState.Die:
                if (healthBoss.currentHealth <= 0)
                {
                    healthBoss.Die();
                    
                }
                break;

            default:
                break;
        }
    }

    void TransitionToState(BossState nextState)
    {
        currentState = nextState;
    }
}

