using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyMovement
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    int secondsPerBullet;
    float bulletTimer;
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

    void BulletTimer() 
    {
        bulletTimer += 1 * Time.deltaTime;
        if (bulletTimer > secondsPerBullet) 
        {
            bulletTimer = 0;
        }
    }

    void CheckTargetDirection() 
    {
        if (target.position.x - transform.position.x > 0)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }

    protected override void AttackPlayer()
    {
        if (bulletTimer == 0)
        {
            GameObject shot = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            EnemyBullet shotBehaviour = shot.GetComponent<EnemyBullet>();
            shotBehaviour.SetDirection(direction);
        }
    }

    protected override void ElementBehave()
    {
        if (attacking)
        {
            CheckTargetDirection();
            AttackPlayer();
            BulletTimer();
        }
    }

    private void Update()
    {
        ElementBehave();
    }
}
