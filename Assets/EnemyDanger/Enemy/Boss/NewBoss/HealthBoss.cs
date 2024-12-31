using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    [SerializeField] public float maxHealth = 20;
    [SerializeField] public float currentHealth;

    public goldenKey prefab;

    [SerializeField] Animator bossAnimator;
    [SerializeField] BossStateMachine stateMachine;
    [SerializeField] ImageController imageController;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
        imageController = GetComponent<ImageController>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public bool isTakeDamage = false;
    
    public void TakeDamage(int damage)
    {
        isTakeDamage = true;
        
        currentHealth -= damage;

        bossAnimator.SetTrigger("Hurt");

                
    }
        
    public void isHurt()
    {
        isTakeDamage = false;
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
        //imageController.triggerObject1.SetActive(false);
        //imageController.triggerObject2.SetActive(false);
        //imageController.triggerObject3.SetActive(false);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Instantiate(prefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z),Quaternion.identity);
        Destroy(stateMachine);

        


    }
    

   
}
