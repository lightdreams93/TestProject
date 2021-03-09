using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectableItem
{
    public static event Action OnTakedCoin; 

    public void Taked()
    {
        OnTakedCoin?.Invoke();
        Destroy(gameObject);
    }
}
