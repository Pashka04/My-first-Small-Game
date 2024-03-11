using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
   [SerializeField] private Animator bossAnimator;
   [SerializeField] private bool canAttack = true;

    public float attackCooldown = 2f;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
    }

}
