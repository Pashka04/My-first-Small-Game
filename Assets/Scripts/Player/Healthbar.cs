using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
   


    


    private void Start()
    {
        totalhealthBar.fillAmount = 1f;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth /9;
    }
}
