using System;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletsContainer;
    [SerializeField] private float _shootDistance;

    private Transform _bullet;
    public static bool canShoot = true;

    public static event Action OnShoot;

    private RaycastHit _hit;

    private void Update()
    { 
        if (canShoot) { 
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out _hit, Mathf.Infinity))
                {
                    float distance = Vector3.Distance(transform.position, _hit.collider.transform.position);
                    IShootableItem shootableItem = _hit.collider.gameObject.GetComponent<IShootableItem>();
                    if (shootableItem != null) { 
                        if(distance < _shootDistance) {
                            canShoot = false;
                            SpawnBullet();
                            OnShoot?.Invoke();
                        }
                    }
                }
            }
        }

        if (_bullet && _hit.collider) { 
            MoveBulletTo(_hit.collider.transform);
        }
    }

    private void SpawnBullet()
    {
        if(_bulletsContainer.transform.childCount > 0)
        {
            Transform bullet = _bulletsContainer.transform.GetChild(0);
            _bullet = bullet;
            bullet.gameObject.SetActive(true);
            bullet.SetParent(null);
            bullet.transform.position = transform.position + Vector3.up;
        }
    }

    private void MoveBulletTo(Transform target) {
        _bullet.transform.position = Vector3.MoveTowards(_bullet.transform.position, target.transform.position, Time.deltaTime * 10f);
    }

    public void MoveToPool()
    {
        _bullet.transform.position = _bulletsContainer.transform.position;
        _bullet.SetParent(_bulletsContainer.transform);
        _bullet.gameObject.SetActive(false);
    }
}
