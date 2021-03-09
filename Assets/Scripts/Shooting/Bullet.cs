using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Shooting shooting; 

    private void OnCollisionEnter(Collision collision)
    {
        IShootableItem shootableItem = collision.gameObject.GetComponent<IShootableItem>();
        if(shootableItem != null)
        {
            shooting.MoveToPool();
            shootableItem.OnHit(); 
            Shooting.canShoot = true;
           
        }
    }
     
}
