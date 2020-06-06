using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyMovement
{
    [SerializeField]
    int bulletsPerSecond;
    int bulletTimer;
    protected override void ElementAwake()
    {
        base.ElementAwake();
        target = PlayerMovement.instance.gameObject.GetComponent<Transform>();
        attacking = false;
        direction = false;
        bulletTimer = 0;
    }

    private void Awake()
    {
        ElementAwake();
    }

    protected override void AttackPlayer()
    {
    }

    protected override void ElementBehave()
    {
        if (attacking)
        {
            AttackPlayer();
        }
    }

    private void Update()
    {
        ElementBehave();
    }
}
