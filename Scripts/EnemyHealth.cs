using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyAnimator _enemyAnimator;
    public int _health;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    public void Death()
    {
        if (_health <= 0)
        {
            _enemyAnimator.Death();
        }
        
    }
    
}
