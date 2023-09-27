using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _angularSpeed;

    [SerializeField] private GameObject _pointsContainer;

    public static event Action OnEndPoint;

    private int _nextPoint; 
    private bool _isButtonPressed;

    private void Update()
    {
		
        if (!_isButtonPressed)
        {
            if (Input.GetMouseButtonDown(0)) {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity)) {
                    IShootableItem shootableItem = hit.collider.GetComponent<IShootableItem>();
                    if(shootableItem == null) { 
                        _isButtonPressed = true;
                    }
                } else
                {
                    _isButtonPressed = true;
                }
            }
        }

        if (_isButtonPressed)
        { 
            if (!isPlayerOnPoint(out _nextPoint)) {  
                MoveTo(_pointsContainer.transform.GetChild(_nextPoint));
                if(_nextPoint < _pointsContainer.transform.childCount - 1) { 
                    LookAt(_pointsContainer.transform.GetChild(_nextPoint + 1), _angularSpeed);
                }

                CheckLastPoint();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ICollectableItem collectableItem = collision.gameObject.GetComponent<ICollectableItem>();
        if (collectableItem != null)
        {
            collectableItem.Taked();
        }
    }

    private bool isPlayerOnPoint(out int index)
    {
        index = _nextPoint;

        bool isEqualsPosZ = transform.position.z == _pointsContainer.transform.GetChild(index).position.z;
        bool isEqualsPosX = transform.position.x == _pointsContainer.transform.GetChild(index).position.x;

        if (isEqualsPosZ && isEqualsPosX)
        { 
            if (index < _pointsContainer.transform.childCount - 1) {
                _isButtonPressed = false;
                index++;
                return true;
            }  
        }
        return false;
    }

    private void MoveTo(Transform target)
    { 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), Time.deltaTime * _speed);
    }

    private void LookAt(Transform target, float speed)
    { 
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
    }

    private void CheckLastPoint()
    {
        int lastIndex = _pointsContainer.transform.childCount - 1;
        bool isEqualsPosZ = transform.position.z == _pointsContainer.transform.GetChild(lastIndex).position.z;
        bool isEqualsPosX = transform.position.x == _pointsContainer.transform.GetChild(lastIndex).position.x;


        if (isEqualsPosX && isEqualsPosZ)
        {
            OnEndPoint?.Invoke();
        }
    }
}
