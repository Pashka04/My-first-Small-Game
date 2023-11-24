using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour 
{
    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private float horizontalInput;
    private bool onGround = true;
    private Rigidbody2D rb;
    private Animator animator;
    private bool Grounded;
    public int coins;
    public Text TextCoins;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 2;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    private StaminaManager staminaManager;
    AttackBonus attackBonus;
    //private bool onWall = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        staminaManager = GetComponent<StaminaManager>();
    }

    private void FixedUpdate()
    {

        animator.SetBool("Run", horizontalInput != 0);
        horizontalInput = Input.GetAxis("Horizontal");
        float jump = Input.GetAxisRaw("Jump");
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);

        if (jump > 0 && onGround && staminaManager.WasteOfStaminaJump()) 
        {
            movement.y = jumpForce;
            AudioManager.Instance.PlaySFX("Jump");
           

        }     

        rb.velocity = movement;
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(3, 3, 1);

        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }

        
    }
    public float GetJumpForce()
    {
        // Метод для получения текущей высоты прыжка
        return jumpForce;
    }

    public void SetJumpForce(float newForce)
    {
        // Метод для установки новой высоты прыжка
        jumpForce = newForce;
    }

    public float GetMoveSpeed()
    {
        // Метод для получения текущей скорости персонажа
        return speed;
    }

    public void SetMoveSpeed(float newSpeed)
    {
        // Метод для установки новой скорости
        speed = newSpeed;
    }

    public int GetAttack()
    {
        // Метод для получения текущего урона
        return attackDamage;
    }

    public void SetAttack(int newAttackDamage)
    {
        // Метод для установки нового урона
        attackDamage = newAttackDamage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& canAttack && staminaManager.WasteOfStaminaAttack())
        {
            Attack();
        }
    }  

    bool canAttack = true;

    private void ResetAttack()
    {
        canAttack = true;
    }


    private void Attack()
    {
               
        canAttack = false;
        
        // Play anim
           animator.SetTrigger("Attack");
        // Range attack
        AudioManager.Instance.PlaySFX("Attack");

        Invoke("ResetAttack", 1f);
    }

    private void Hit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            onGround = true;
            animator.SetBool("Grounded", true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            onGround = false;
            animator.SetBool("Grounded", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
           TextCoins.text = (coins + 1).ToString();
           gameObject.SetActive(false);
        }


    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

   
    
    






} 
