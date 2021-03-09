using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour, IShootableItem
{
    public void OnHit()
    {
        Destroy(gameObject);   
    }
}
