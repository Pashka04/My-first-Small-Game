using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject coinTakedPrefab;

    [SerializeField] private int ID = 0;

    private CoinBank coinBank;

    private void Start()
    {
        coinBank = FindObjectOfType<CoinBank>();
        if (!coinBank.IsContainsIdOnList(ID))
        {
            SpawnCoin();
        }
        else
        {
            SpawnTakedCoin();
        }
    }

    private void SpawnCoin()
    {
        GameObject coinObj = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        CoinInstance coinsInstance = coinObj.GetComponent<CoinInstance>();
        coinsInstance.OnCoinCollected += OnCoinCollected;
    }

    private void SpawnTakedCoin()
    {
        GameObject coinObj = Instantiate(coinTakedPrefab, transform.position, Quaternion.identity);
    }

    private void OnCoinCollected(int value)
    {
        if (coinBank != null)
        {
            coinBank.AddCoin(value, ID);

            var textUI = FindObjectOfType<CoinUIHendler>();
            textUI.SetText(coinBank.GetCoinsCollected().ToString());
        }
    }
}
