using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class PlayerJump : SingletonBase<PlayerJump>
{
    [SerializeField]
    int jumpSpeed;
    [SerializeField]
    float maxJumpTime;
    float jumpTime;
    bool firstJump;
    bool hooking;
    bool pressingHooking;
    bool stoppedHooking;
    Vector2 velocity;
    Rigidbody2D rbd;
    float GRAVITYSCALE;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        jumpTime = 0;
        rbd = GetComponent<Rigidbody2D>();
        GRAVITYSCALE = rbd.gravityScale;
        firstJump = false;
        hooking = false;
        pressingHooking = false;
        stoppedHooking = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Jump()
    {
        if (InputManager.instance.inputDetected())
        {
            if (Input.GetKey(InputManager.instance.jump) && !firstJump && jumpTime < maxJumpTime)
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
            firstJump = true;
        }
    }

    void ResetJump()
    {
        if ((rbd.velocity.y == 0 && firstJump == true || rbd.velocity.y == 0 && jumpTime >= maxJumpTime) &&
            hooking == false)
        {
            firstJump = false;
            stoppedHooking = false;
            jumpTime = 0;
        }
    }

    void HookPendulum() 
    {
        if (InputManager.instance.inputDetected() && PlayerPendulum.instance != null)
        {
            if (Input.GetKey(InputManager.instance.jump) && firstJump && !stoppedHooking && !pressingHooking)
            {
                if (!hooking)
                {
                    hooking = true;
                    PlayerPendulum.instance.SetActivated(true);
                    velocity = rbd.velocity;
                    velocity.y = 0;
                    rbd.velocity = velocity;
                    jumpTime = 0;
                    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                else 
                {
                    stoppedHooking = true;
                    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = GRAVITYSCALE;
                    hooking = false;
                    PlayerPendulum.instance.SetActivated(false);
                    PlayerPendulum.instance.StopPendularMovement();
                    velocity = rbd.velocity;
                    velocity.y = jumpSpeed;
                    rbd.velocity = velocity;
                    jumpTime += 1 * Time.deltaTime;
                }
                pressingHooking = true;
            }
        }
        if (Input.GetKeyUp(InputManager.instance.jump)) 
        {
            pressingHooking = false;
        }
    }

    protected override void BehaveSingleton()
    {
        Jump();
        HookPendulum();
        CheckJump();
        ResetJump();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
