using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        if (GameManager.playerHealth!= 0)
        {
            currentHealth = GameManager.playerHealth;

        }
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {   if (!dead)
            {

                anim.SetTrigger("Die");
                GetComponent<PlayerController>().enabled = false;
                dead = true;
                AudioManager.Instance.PlaySFX("Dead");
                GameObject.Find("GameManager").GetComponent<SceneController>().RestartLevel();
                

            }
        }


       
    }

    

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
  
    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }
}
