using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Idle : MonoBehaviour
{
    [SerializeField] private Trigger trigger;
    

    [Header("Boss")]
    [SerializeField] private Transform enemy;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        trigger.PlayerInZone.AddListener(OnPlayerInZone);
        trigger.PlayerOffZone.AddListener(OnPlayerOffZone);
    }

    void OnPlayerInZone()
    {
        anim.SetBool("Moving", true);
    }

    void OnPlayerOffZone()
    {
        anim.SetBool("Moving", false);
    }

    
}
