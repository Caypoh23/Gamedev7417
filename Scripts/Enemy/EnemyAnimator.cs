using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        //why public?
        public Animator _animator;
        
        //such methods is not a good idea as they are not readable
        //name is illogical comparing to the actual process in function
        public void Move(bool canWalk)
        {
            _animator.SetBool("CanWalk", canWalk);
        }
        public void Attack(bool canAttack)
        {
            _animator.SetBool("Attack", canAttack);
        }

        public void Death()
        {
            _animator.SetTrigger("Death");
        }
    }
}

