using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyMovement
{
    [SerializeField]
    GameObject pointA;
    [SerializeField]
    GameObject pointB;

    protected override void ElementAwake()
    {
        base.ElementAwake();
        target = PlayerMovement.instance.gameObject.GetComponent<Transform>();
        attacking = false;
        direction = false;
    }

    private void Awake()
    {
        ElementAwake();
    }

    protected override void AttackPlayer()
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

    void ChangeDirection() 
    {
        if (direction == false)
        {
            direction = true;
            return;
        }
        direction = false;
    }

    protected override void Moving()
    {
        float distance;
        Vector3 dir;
        if (direction == false)
        {
            distance = Vector3.Distance(transform.position, pointA.gameObject.transform.position);
            dir = pointA.gameObject.transform.position - transform.position;
        }
        else 
        {
            distance = Vector3.Distance(transform.position, pointB.gameObject.transform.position);
            dir = pointB.gameObject.transform.position - transform.position;
        }
        dir.y = 0.0f;
        dir.Normalize();
        if (distance > 1)
        {
            transform.position += dir * enemySpeed * Time.deltaTime;
        }
        else 
        {
            ChangeDirection();
        }
    }

    protected override void ElementBehave()
    {
        if (!attacking)
        {
            Moving();
        }
        else 
        {
            AttackPlayer();
        }
    }

    private void Update()
    {
        ElementBehave();
    }
}
