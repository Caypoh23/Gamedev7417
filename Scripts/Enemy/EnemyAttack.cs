using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        
        [SerializeField] private float _attackDistance; //Minimum distance for attack
        public float _timer; //Timer for cooldown between attacks
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyAnimator _anim;
        private float _distance; //Store the distance b/w enemy and player
        [HideInInspector] public bool _attackMode;
        private bool _isCooling; //Check if Enemy is cooling after attack
        [HideInInspector] public float _intTimer;
        
        //naming is unclear and not clear why public
        public void EnemyLogic()
        {
            _distance = Vector2.Distance(transform.position, _movement.Target.position);
    
            if (_distance > _attackDistance)
            {
                StopAttack();
            }
            else if (_attackDistance >= _distance && _isCooling == false)
            {
                Attack();
            }
    
            if (_isCooling)
            {
                Cooldown();
                _anim.Attack(false);
            }
        }
    
        public void Attack()
        {
            _timer = _intTimer; //Reset Timer when Player enter Attack Range
            _attackMode = true; //To check if Enemy can still attack or not
    
            _anim.Move(false);
            _anim.Attack(true);
        }
    
        public void Cooldown()
        {
            _timer -= Time.deltaTime;
    
            if (_timer <= 0 && _isCooling && _attackMode)
            {
                _isCooling = false;
                _timer = _intTimer;
            }
        }
        //why not to use states??? you can use enum to define current state
        //using many bool is not the best practice
        public void StopAttack()
        {
            _isCooling = false;
            _attackMode = false;
            _anim.Attack(false);
        }
        
        public void TriggerCooling()
        {
            _isCooling = true;
        }
    
    }

}
