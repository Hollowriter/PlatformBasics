using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : ElementBase
{
    [SerializeField]
    int timeAlive;
    [SerializeField]
    float speed;
    float timer;
    bool direction;

    protected override void ElementAwake()
    {
        base.ElementAwake();
        timer = 0;
        direction = false;
    }

    private void Awake()
    {
        ElementAwake();
    }

    public void SetDirection(bool _direction) 
    {
        direction = _direction;
    }

    public bool GetDirection() 
    {
        return direction;
    }

    void ShotMovement() 
    {
        if (direction)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void TimerForDestruction() 
    {
        if (timer < timeAlive)
        {
            timer += 1 * Time.deltaTime;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    protected override void ElementBehave()
    {
        if (this.gameObject.activeInHierarchy) 
        {
            ShotMovement();
            TimerForDestruction();
        }
    }

    private void Update()
    {
        ElementBehave();
    }
}
