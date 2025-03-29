using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBank : MonoBehaviour
{
    private CoinBankData coinBankData;

    private void Awake()
    {
        
        //PlayerPrefs.DeleteAll();
        //Debug.Log("PlayerPrefs очищены!");
        PlayerPrefs.Save();
        LoadData();
        var textUI = FindObjectOfType<CoinUIHendler>();
        textUI.SetText(GetCoinsCollected().ToString());
    }

    public void AddCoin(int value, int SpawnerID)
    {
        coinBankData.coinsCollected += value;
        coinBankData.coinSpawnerIDs.Add(SpawnerID);
        SaveData();
    }
    public void RemoveCoin(int value)
    {
        coinBankData.coinsCollected -= value;
        SaveData();
    }
    public int GetCoinsCollected()
    {
        return coinBankData.coinsCollected;
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(coinBankData);
        PlayerPrefs.SetString("CoinBankData", json);
    }

    private void LoadData()
    {
        string json = PlayerPrefs.GetString("CoinBankData", "");
        coinBankData = string.IsNullOrEmpty(json) ? new CoinBankData() : JsonUtility.FromJson<CoinBankData>(json);
    }

    public bool IsContainsIdOnList(int id)
    {
        return coinBankData.coinSpawnerIDs.Contains(id);
    }
}
