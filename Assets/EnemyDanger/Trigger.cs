using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] Boss_Idle boss;
    public UnityEvent PlayerInZone;
    public UnityEvent PlayerOffZone;

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInZone.Invoke();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerOffZone.Invoke();
    }

    
    
}
