using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

//script has mix of resposibilities - store HP and show animation
//I would suggest to separate it and link them with events
public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyAnimator _enemyAnimator;
    public int _health;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        //why can't this function call deadth function?
    }
    
    //why this is a public function?
    //why name of the function is a noun?
    //I have't found where in other scripts this function is called
    public void Death()
    {
        if (_health <= 0)
        {
            _enemyAnimator.Death();
        }
        
    }
    
}
