using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class HopperEnemy : MonoBehaviour
{

    [HideInInspector] public bool inRange; //Check if Player is in range
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyAttack _attack;
    [SerializeField] private EnemyAnimator _anim;
    public GameObject HotZone;
    public GameObject TriggerArea;

    private void Awake()
    {
        _movement.SelectTarget();
        _attack._intTimer = _attack._timer; //Store the inital value of timer
        
    }

    private void Update()
    {
        if (!_attack._attackMode)
        {
            _movement.Move();
        }

        if (!_movement.InsideOfLimits() && !inRange && !_anim._animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            _movement.SelectTarget();
        }

        if (inRange)
        {
            _attack.EnemyLogic();
        }
    }
}
