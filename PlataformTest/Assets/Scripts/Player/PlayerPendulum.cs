using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPendulum : SingletonBase<PlayerPendulum>
{
    [SerializeField]
    GameObject parentVehicle;
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
        timer += Time.fixedDeltaTime;
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
        transform.Rotate(rotationVector);
    }

    void PhaseController() 
    {
        if (timer > maxTimer)
        {
            phase++;
            phase %= 4;
            timer = 0f;
        }
    }
}
