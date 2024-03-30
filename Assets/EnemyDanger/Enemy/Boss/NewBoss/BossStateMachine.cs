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
        switch (currentState)
        {
            case BossState.Idle:
                anim.Play("Idle");
                if (attackBoss.PlayerInSight())
                {
                    TransitionToState(BossState.Attack);
                }
                break;

            case BossState.Attack:
                anim.SetTrigger("Attack");
                if (!attackBoss.PlayerInSight())
                {
                    TransitionToState(BossState.Run);
                }
                break;

            case BossState.Run:
                bossRange.IsRun = true;
                if (bossRange.PlayerOutOfRange())
                {
                    TransitionToState(BossState.Idle);
                }
                if (healthBoss.TakeDamage())
                {
                    TransitionToState(BossState.Hurt);

                }
                break;

            case BossState.Hurt:
                anim.SetTrigger("Hurt");
                if (healthBoss.currentHealth > 0)
                {

                    bossRange.StopChasingPlayer();
                    TransitionToState(BossState.Idle);

                    
                    // Implement retreat behavior here
                    // For example, move back or teleport

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
                    // Add any additional actions for when the boss dies
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

