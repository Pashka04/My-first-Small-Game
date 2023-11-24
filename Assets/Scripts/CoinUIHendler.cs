using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUIHendler : MonoBehaviour
{
    [SerializeField] private Text textCoin;

    public void SetText(string _text)
    {
        textCoin.text = _text;
    }

}
