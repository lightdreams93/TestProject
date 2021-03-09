using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IShootableItem
{
    [SerializeField] private int _lifeCount = 3;

    public static event Action<int, GameObject> OnHitEvent;
    public static event Action<GameObject> OnEnemyDead;

    public void OnHit()
    { 
        if(_lifeCount > 1)
        {
            _lifeCount--;
            OnHitEvent?.Invoke(_lifeCount, gameObject);
            return;
        }

        Death();
    }
    private void Death()
    {
        Destroy(gameObject);
        OnEnemyDead?.Invoke(gameObject);
    }
}
