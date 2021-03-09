using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        Shooting.OnShoot += Shooting_OnShoot;
    }

    private void Shooting_OnShoot()
    {
        _audioSource.PlayOneShot(_clip);
    }

    private void OnDestroy()
    {
        Shooting.OnShoot -= Shooting_OnShoot;
    }
}
