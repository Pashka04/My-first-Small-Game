using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float playerHealth;
    
    
    private void Start()
    {
        
 
    
    
    }

     public static void SaveHealth()
    {
        var currentPlayerHealth = GameObject.Find("Player").GetComponent<Health>().GetCurrentHealth();
        playerHealth = currentPlayerHealth;

        Debug.Log(playerHealth);
    }

}





