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
            Debug.Log(rotationVector.z);
            phase++;
            phase %= 4;
            timer = 0f;
        }
    }

    public void ForcePhase(int _phase) 
    {
        phase = _phase;
    }

    public int GetPhase() 
    {
        return phase;
    }

    public void StopPendularMovement() 
    {
        rotationVector.z = 0;
        toRotate.transform.Rotate(rotationVector);
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
