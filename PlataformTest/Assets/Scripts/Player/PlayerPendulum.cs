using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPendulum : SingletonBase<PlayerPendulum>
{
    [SerializeField]
    GameObject toRotate;
    [SerializeField]
    GameObject haloSprite;
    [SerializeField]
    GameObject ropeSprite;
    Vector3 rotationVector;
    [SerializeField]
    float maxTimer;
    [SerializeField]
    float speed;
    int phase;
    float timer;
    bool pressed;
    bool collectableCollected;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rotationVector = Vector3.zero;
        phase = 0;
        timer = 0;
        pressed = false;
        collectableCollected = false;
        haloSprite.gameObject.SetActive(false);
        ropeSprite.gameObject.SetActive(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void PendularSprites() 
    {
        if (!haloSprite.gameObject.activeInHierarchy || !ropeSprite.gameObject.activeInHierarchy) 
        {
            haloSprite.gameObject.SetActive(true);
            ropeSprite.gameObject.SetActive(true);
        }
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

    public void ForcePhase(int _phase) 
    {
        phase = _phase;
    }

    public int GetPhase() 
    {
        return phase;
    }

    public void SetCollectionConfirmation(bool _collectableCollected) 
    {
        collectableCollected = _collectableCollected;
    }

    public bool GetCollectionConfirmation() 
    {
        return collectableCollected;
    }

    public void StopPendularMovement() 
    {
        timer = 0;
        phase = 0;
        toRotate.transform.rotation = Quaternion.identity;
        haloSprite.gameObject.SetActive(false);
        ropeSprite.gameObject.SetActive(false);
    }

    protected override void BehaveSingleton()
    {
        if (GetActivated())
        {
            PhaseController();
            PendularMovement();
            PendularSprites();
        }
    }

    private void FixedUpdate()
    {
        BehaveSingleton();
    }
}
