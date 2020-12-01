
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private float _projectileSpeed = 30;
    [SerializeField] private Rigidbody2D _rigid;

    private void Start()
    {
        _rigid.velocity = transform.right * _projectileSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Instantiate(_impactEffect, transform.position, _rigid.transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
