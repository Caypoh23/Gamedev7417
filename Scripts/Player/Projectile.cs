
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
        //using tags is not the best idea as tags are string and can be changed. may by to add an empty script for playera and enemy
        //or even try to get component of interface IDamagable as it is used both on player and enemy - this will be indicator that it is damageble object
        if (!collision.CompareTag("Enemy") && !collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Instantiate(_impactEffect, transform.position, _rigid.transform.rotation);
            Destroy(gameObject);
        }
        
    }
}
