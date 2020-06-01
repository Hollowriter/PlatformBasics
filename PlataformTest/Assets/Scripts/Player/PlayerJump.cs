using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerJump : SingletonBase<PlayerJump>
{
    [SerializeField]
    int jumpSpeed;
    [SerializeField]
    float maxJumpTime;
    float jumpTime;
    Vector2 velocity;
    Rigidbody2D rbd;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpTime = 0;
        rbd = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump() 
    {
        if (InputManager.instance.inputDetected()) 
        {
            if (Input.GetKey(InputManager.instance.jump)) 
            {
                velocity = rbd.velocity;
                velocity.y = jumpSpeed;
                rbd.velocity = velocity;
            }
        }
    }

    protected override void BehaveSingleton()
    {
        Jump();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
