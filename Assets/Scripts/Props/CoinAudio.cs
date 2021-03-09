using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    private void Start()
    {
        Coin.OnTakedCoin += Coin_OnTakedCoin;
    }

    private void Coin_OnTakedCoin()
    {
        audioSource.PlayOneShot(audioClip);
    }
    private void OnDestroy()
    {
        Coin.OnTakedCoin -= Coin_OnTakedCoin;
    }
}
