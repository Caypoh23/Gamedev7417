using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour, IFlippable
    {
        
        [SerializeField] private Transform _leftLimit;
        [SerializeField] private Transform _rightLimit;
        [HideInInspector] public Transform Target;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private EnemyAnimator _anim;
        
        public void Move()
        {
            _anim.Move(true);

            if (!_anim._animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                Vector2 targetPosition = new Vector2(Target.position.x, transform.position.y);

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
            }
        }
        
        public bool InsideOfLimits()
        {
            return transform.position.x > _leftLimit.position.x && transform.position.x < _rightLimit.position.x;
        }
        
        public void SelectTarget()
        {
            float distanceToLeft = Vector3.Distance(transform.position, _leftLimit.position);
            float distanceToRight = Vector3.Distance(transform.position, _rightLimit.position);
            
            Target = distanceToLeft > distanceToRight ? _leftLimit : _rightLimit;

            Flip();
        }

        public void Flip()
        {
            if (transform.position.x > Target.position.x) 
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}

