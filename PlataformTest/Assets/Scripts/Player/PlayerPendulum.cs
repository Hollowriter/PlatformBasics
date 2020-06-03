using System.Collections;
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
    bool colliding;
    float timer;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rotationVector = Vector3.zero;
        phase = 0;
        timer = 0;
        colliding = false;
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
                Debug.Log("Case0: " + rotationVector.z);
                break;
            case 1:
                rotationVector.z = -speed * timer;
                Debug.Log("Case1: " + rotationVector.z);
                break;
            case 2:
                rotationVector.z = -speed * (1 - timer);
                Debug.Log("Case2: " + rotationVector.z);
                break;
            case 3:
                rotationVector.z = speed * timer;
                Debug.Log("Case3: " + rotationVector.z);
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

    protected override void BehaveSingleton()
    {
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
