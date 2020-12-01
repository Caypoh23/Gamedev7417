using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class TriggerAreaCheck : MonoBehaviour
    {
        [SerializeField] private HopperEnemy _hopperEnemy;
        [SerializeField] private EnemyMovement _movement;
            private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                _movement.Target = collider.transform;
                _hopperEnemy.inRange = true;
                _hopperEnemy.HotZone.SetActive(true);
            }
        }
    }

}
