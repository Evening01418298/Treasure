using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] LayerMask playerLayer;

    void Attack()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, attackRadius, transform.forward, out hit, attackRange, playerLayer))
        {

        }

    }
}
