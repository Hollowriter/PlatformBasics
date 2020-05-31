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

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        velocity = Vector2.zero;
        rbd = GetComponent<Rigidbody2D>();
        SetActivated(true);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void PressingRight()
    {
        velocity.x += characterSpeed * Time.deltaTime;
        if (velocity.x > characterSpeed)
            velocity.x = characterSpeed;
        rbd.velocity = velocity;
    }

    void PressingLeft()
    {
        velocity.x -= characterSpeed * Time.deltaTime;
        if (velocity.x < -characterSpeed)
            velocity.x = -characterSpeed;
        rbd.velocity = velocity;
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
        velocity.x = 0;
        rbd.velocity = velocity;
    }

    protected override void BehaveSingleton()
    {
        Movement();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
