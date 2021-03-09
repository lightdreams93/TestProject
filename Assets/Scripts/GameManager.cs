using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _countEnemies;
    
    private bool _isAllDead;

    private void Start()
    {
        Enemy.OnEnemyDead += Enemy_OnEnemyDead;
        Player.OnEndPoint += Player_OnEndPoint;
    }

    private void Player_OnEndPoint()
    {
        if(_isAllDead)
        {
            Debug.Log("Win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
        else
        {
            Debug.Log("Loose!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Enemy_OnEnemyDead(GameObject obj)
    {
        if(_countEnemies > 1)
            _countEnemies--;
        else
            _isAllDead = true;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDead -= Enemy_OnEnemyDead;
        Player.OnEndPoint -= Player_OnEndPoint;
    }
}
