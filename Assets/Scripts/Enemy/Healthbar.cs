using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private GameObject _heartContainer;

    public GameObject HeartContainer { get => _heartContainer; }

    private void Start() => Enemy.OnHitEvent += Enemy_OnHitEvent;

    private void Enemy_OnHitEvent(int hearts, GameObject obj)
    {
        Healthbar healthbar = obj.GetComponent<Healthbar>();

        for (int i = 0; i < healthbar.HeartContainer.transform.childCount; i++)
        {
            GameObject heart = healthbar.HeartContainer.transform.GetChild(i).gameObject;

            if (i < hearts)
                heart.SetActive(true);
            else
                heart.SetActive(false);
        }
    }

    private void OnDestroy() => Enemy.OnHitEvent -= Enemy_OnHitEvent;
}
