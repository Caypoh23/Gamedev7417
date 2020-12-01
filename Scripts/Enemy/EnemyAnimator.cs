using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        public Animator _animator;

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

