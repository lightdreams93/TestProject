using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    private int count;

    private void Start()
    {
        Enemy.OnEnemyDead += Enemy_OnEnemyDead;
    }

    private void Enemy_OnEnemyDead(GameObject shootableItem)
    {
        Enemy enemy = shootableItem.GetComponent<Enemy>();
        if(enemy) { 
            count++;
            _counterText.text = count.ToString();
        }
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDead -= Enemy_OnEnemyDead;
    }
}
