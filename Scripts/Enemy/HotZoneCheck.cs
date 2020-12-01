using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    [SerializeField] private HopperEnemy _hopperEnemy;
    [SerializeField] private EnemyAnimator _anim;
    [SerializeField] private EnemyMovement _movement;
    private bool _inRange;

    private void Update()
    {
        if (_inRange && !_anim._animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            _movement.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _inRange = false;
            gameObject.SetActive(false);
            _hopperEnemy.TriggerArea.SetActive(true);
            _hopperEnemy.inRange = false;
            _movement.SelectTarget();
        }
    }
}
