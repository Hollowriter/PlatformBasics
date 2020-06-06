using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMovement : ElementBase
{
    protected Transform target;
    [SerializeField]
    protected float enemySpeed;
    protected bool attacking;
    protected bool direction;

    public void SetAttacking(bool _attacking)
    {
        attacking = _attacking;
    }

    public bool GetAttacking() 
    {
        return attacking;
    }

    protected virtual void AttackPlayer() 
    {
    }

    protected virtual void Moving() 
    {
    }
}
