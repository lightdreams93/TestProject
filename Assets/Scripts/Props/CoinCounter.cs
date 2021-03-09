using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _textCoin;

    private int _countCount;
    
    private void Start()
    {
        Coin.OnTakedCoin += Coin_OnTakedCoin;
    }

    private void Coin_OnTakedCoin()
    {
        _countCount++;
        _textCoin.text = _countCount.ToString();
    }

    private void OnDestroy()
    {
        Coin.OnTakedCoin -= Coin_OnTakedCoin;
    }
}
