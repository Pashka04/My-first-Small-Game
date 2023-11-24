using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinInstance : MonoBehaviour
{
    public event Action<int> OnCoinCollected;

    [SerializeField] private int coinCost = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCoinCollected?.Invoke(coinCost);

            Destroy(gameObject);
        }
    }
}
