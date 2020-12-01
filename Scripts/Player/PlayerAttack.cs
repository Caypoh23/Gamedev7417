using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _firePosition;
    [SerializeField] private GameObject _projectile;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_projectile, _firePosition.position, _firePosition.rotation);
        }
    }
}
