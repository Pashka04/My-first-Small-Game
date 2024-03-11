using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 20;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	Animator anim;

	


	private void Awake()
	{
		anim = GetComponent<Animator>();
		
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		anim.SetTrigger("Hurt");

		if (health <= 10)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		anim.SetBool("IsDead", true);
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}

	private void Deactivate()
	{
		gameObject.SetActive(false);
	}

}
