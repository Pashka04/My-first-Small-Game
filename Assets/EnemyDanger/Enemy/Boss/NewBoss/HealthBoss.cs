using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    [SerializeField] public int maxHealth = 5;
    [SerializeField] public int currentHealth;
    

    [SerializeField] Animator bossAnimator;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;

        bossAnimator.SetTrigger("Hurt");
        
        return true;
        
    }

    public bool CheckDeath()
    {
        if (currentHealth <= 0)
        {
            return true;
            
        }
        return false;
    }

    
    public void Die()
    {
        Debug.Log("Boss died!");
        bossAnimator.SetBool("IsDie", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;



    }

   
}
