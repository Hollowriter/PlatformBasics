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
    bool pressingStopped;
    Vector2 velocity;
    Rigidbody2D rbd;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpTime = 0;
        rbd = GetComponent<Rigidbody2D>();
        pressingStopped = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump() 
    {
        if (InputManager.instance.inputDetected()) 
        {
            if (Input.GetKey(InputManager.instance.jump) && !pressingStopped && jumpTime < maxJumpTime) 
            {
                velocity = rbd.velocity;
                velocity.y = jumpSpeed;
                rbd.velocity = velocity;
                jumpTime += 1 * Time.deltaTime;
            }
        }
    }

    void CheckJump() 
    {
        if (Input.GetKeyUp(InputManager.instance.jump) && jumpTime > 0) 
        {
            pressingStopped = true;
        }
    }

    void ResetJump() 
    {
        if (rbd.velocity.y == 0 && pressingStopped == true || rbd.velocity.y == 0 && jumpTime >= maxJumpTime) 
        {
            pressingStopped = false;
            jumpTime = 0;
        }
    }

    protected override void BehaveSingleton()
    {
        Jump();
        CheckJump();
        ResetJump();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
