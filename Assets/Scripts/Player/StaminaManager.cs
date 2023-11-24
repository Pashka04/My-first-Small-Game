using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaManager : MonoBehaviour
{
    private float stamina = 100;
    public float staminaAttack = 15;
    public float staminaJump = 10;
    [SerializeField] private Image slider;

    public bool WasteOfStaminaAttack()
    {
        if (stamina >= staminaAttack)
        {
            stamina -= staminaAttack;
            UpdateSlider();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateSlider()
    {
        slider.GetComponent<Image>().fillAmount = stamina/100; 
    }

    public bool WasteOfStaminaJump()
    {
        if (stamina >= staminaJump)
        {
            stamina -= staminaJump;
            UpdateSlider();
            return true;
        }
        else
        {
            return false;
        }

        
    }


    private void Start()
    {
        InvokeRepeating("RegenStamina", 1f, 1f);
    }

    public void RegenStamina()
    {
        if (stamina < 100)
        {
            stamina += 5f;
            UpdateSlider();
        }
        
    }
    
    


   

}
