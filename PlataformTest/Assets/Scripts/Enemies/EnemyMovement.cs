using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMovement : ElementBase
{
    Transform target;
    [SerializeField]
    float enemySpeed;

    protected override void ElementAwake()
    {
        base.ElementAwake();
        target = PlayerMovement.instance.gameObject.GetComponent<Transform>();
    }

    private void Awake()
    {
        ElementAwake();
    }

    void Chase() 
    {
        float distance = Vector3.Distance(transform.position, target.position);
        Vector3 dir = target.position - transform.position;
        dir.y = 0.0f;
        dir.Normalize();
        if (distance > 0) 
        {
            transform.position += dir * enemySpeed * Time.deltaTime;
        }
    }

    protected override void ElementBehave()
    {
        Chase();
    }

    private void Update()
    {
        ElementBehave();
    }
}
