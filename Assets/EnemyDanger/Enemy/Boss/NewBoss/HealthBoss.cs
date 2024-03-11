using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] Animator bossAnimator;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
    }

    void Die()
    {
        Debug.Log("Boss died!");

        bossAnimator.SetBool("IsDie", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        bossAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
