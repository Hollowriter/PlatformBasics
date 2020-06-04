using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SingletonBase<PlayerMovement>
{
    [SerializeField]
    int characterSpeed;
    Vector2 velocity;
    Rigidbody2D rbd;
    bool direction;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        velocity = Vector2.zero;
        rbd = GetComponent<Rigidbody2D>();
        direction = true;
        SetActivated(true);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetDirection(bool _direction) 
    {
        direction = _direction;
    }

    public bool GetDirection() 
    {
        return direction;
    }

    void PressingRight()
    {
        velocity = rbd.velocity;
        velocity.x += characterSpeed * Time.deltaTime;
        if (velocity.x > characterSpeed)
            velocity.x = characterSpeed;
        rbd.velocity = velocity;
        SetDirection(true);
    }

    void PressingLeft()
    {
        velocity = rbd.velocity;
        velocity.x -= characterSpeed * Time.deltaTime;
        if (velocity.x < -characterSpeed)
            velocity.x = -characterSpeed;
        rbd.velocity = velocity;
        SetDirection(false);
    }

    void StopMovement() 
    {
        if (rbd.velocity.y == 0)
        {
            velocity.x = 0;
            rbd.velocity = velocity;
        }
    }

    void Movement()
    {
        if (InputManager.instance.inputDetected())
        {
            if (Input.GetKey(InputManager.instance.walkRight))
            {
                PressingRight();
                return;
            }
            if (Input.GetKey(InputManager.instance.walkLeft))
            {
                PressingLeft();
                return;
            }
        }
        StopMovement();
    }

    protected override void BehaveSingleton()
    {
        if (!PlayerPendulum.instance.GetActivated())
        {
            Movement();
        }
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
