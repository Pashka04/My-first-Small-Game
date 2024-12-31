using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private HealthBoss bossHealth;
    [SerializeField] public Image totalBar;
    [SerializeField] public Image currentBar;


    void Start()
    {
        totalBar.fillAmount = 200f;
        totalBar.gameObject.SetActive(true);
    }
    private void Update()
    {
        currentBar.fillAmount = bossHealth.currentHealth / 20;
    }

}
