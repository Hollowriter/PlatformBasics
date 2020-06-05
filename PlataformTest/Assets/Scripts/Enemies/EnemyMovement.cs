using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMovement : ElementBase
{
    Transform target;
    [SerializeField]
    float enemySpeed;
    bool chasing;
    bool direction;

    protected override void ElementAwake()
    {
        base.ElementAwake();
        target = PlayerMovement.instance.gameObject.GetComponent<Transform>();
        chasing = false;
        direction = false;
    }

    private void Awake()
    {
        ElementAwake();
    }

    public void SetChase(bool _chase)
    {
        chasing = _chase;
    }

    public bool GetChase() 
    {
        return chasing;
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

    void Moving() 
    {
        
    }

    protected override void ElementBehave()
    {
        if (!chasing)
        {
            Moving();
        }
        else 
        {
            Chase();
        }
    }

    private void Update()
    {
        ElementBehave();
    }
}
