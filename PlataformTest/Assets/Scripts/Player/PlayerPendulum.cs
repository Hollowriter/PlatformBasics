﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPendulum : SingletonBase<PlayerPendulum>
{
    [SerializeField]
    GameObject toRotate;
    Vector3 rotationVector;
    [SerializeField]
    float maxTimer;
    [SerializeField]
    float speed;
    int phase;
    float timer;
    bool pressed;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rotationVector = Vector3.zero;
        phase = 0;
        timer = 0;
        pressed = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void PendularMovement() 
    {
        switch (phase)
        {
            case 0:
                rotationVector.z = speed * (1 - timer);
                break;
            case 1:
                rotationVector.z = -speed * timer;
                break;
            case 2:
                rotationVector.z = -speed * (1 - timer);
                break;
            case 3:
                rotationVector.z = speed * timer;
                break;
        }
        toRotate.transform.Rotate(rotationVector);
    }

    void PhaseController() 
    {
        timer += Time.fixedDeltaTime;
        if (timer > maxTimer)
        {
            phase++;
            phase %= 4;
            timer = 0f;
        }
    }

    /*void SwitchPendulum() 
    {
        if (InputManager.instance.inputDetected() && !pressed)
        {
            if (Input.GetKey(InputManager.instance.jump) && PlayerJump.instance.PressingStopped())
            {
                if (!GetActivated())
                {
                    SetActivated(true);
                    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                else
                {
                    SetActivated(false);
                    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
                pressed = true;
            }
        }
        if (Input.GetKeyUp(InputManager.instance.jump)) 
        {
            Debug.Log("deactivated");
            pressed = false;
        }
    }*/

    protected override void BehaveSingleton()
    {
        // SwitchPendulum(); // FIJARME COMO ACTIVAR Y DESACTIVAR EL MOVIMIENTO DE PENDULO SIN JODER EL SALTO
        if (GetActivated())
        {
            PhaseController();
            PendularMovement();
        }
    }

    private void FixedUpdate()
    {
        BehaveSingleton();
    }
}
