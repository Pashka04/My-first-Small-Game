using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public string objectName;
    public int price, access, level;
    public GameObject block;
    public Text objectPrice, CoinCount;
    public CoinBank coinBank;
    

    private void Awake()
    {
        //PlayerPrefs.SetInt("coins", 0);
        AccessUpdate();
        coinBank = FindObjectOfType<CoinBank>();

    }

    void AccessUpdate()
    {
        Debug.Log("Access updated");
        access = PlayerPrefs.GetInt(objectName + "Access");
        objectPrice.text = price.ToString();
        var textUI = FindObjectOfType<CoinUIHendler>();
        textUI.SetText(coinBank.GetCoinsCollected().ToString());

        if (access == 1)
        {
            block.SetActive(false);
            objectPrice.gameObject.SetActive(false);
        }
    }


    public void BuyShop()
    {
        Debug.Log("Клик");
        int coin = coinBank.GetCoinsCollected();

        if (access == 0)
        {
            if (coin >= price)
            {
                PlayerPrefs.SetInt(objectName + "Access", 1);
                coinBank.RemoveCoin(price);
                AccessUpdate();
            }
        }
        else
        {
            SceneManager.LoadScene(level);
        }
    }

}
