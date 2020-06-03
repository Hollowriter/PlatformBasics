using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAttack : SingletonBase<PlayerAttack>
{
    [SerializeField]
    GameObject attackObject;
    [SerializeField]
    int range;
    [SerializeField]
    float movementSpeed;
    Vector3 movement;
    bool returning;
    int directionModifier;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        movement = Vector3.zero;
        returning = false;
        attackObject.SetActive(false);
        directionModifier = 1;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckDirection()
    {
        if (PlayerMovement.instance.GetDirection()) 
        {
            directionModifier = 1;
            return;
        }
        directionModifier = -1;
    }

    void StartAttack() 
    {
        if (InputManager.instance.inputDetected())
        {
            if (Input.GetKey(InputManager.instance.attack) && !attackObject.activeInHierarchy 
                && (PlayerPendulum.instance == null || !PlayerPendulum.instance.GetActivated()))
            {
                returning = false;
                attackObject.SetActive(true);
                CheckDirection();
            }
        }
    }

    void Attack() 
    {
        if (attackObject.activeInHierarchy) 
        {
            movement.x = movementSpeed * directionModifier * Time.deltaTime;
            if (!returning)
            {
                attackObject.transform.localPosition += movement;
            }
            else 
            {
                attackObject.transform.localPosition -= movement;
            }
        }
    }

    void FinishAttack() 
    {
        if (directionModifier == 1 && !returning && attackObject.transform.localPosition.x > range ||
            directionModifier == -1 && !returning && attackObject.transform.localPosition.x < range * -1)
        {
            returning = true;
        }
        else if (directionModifier == 1 && returning && attackObject.transform.localPosition.x <= 0 ||
                 directionModifier == -1 && returning && attackObject.transform.localPosition.x >= 0) 
        {
            attackObject.transform.localPosition = Vector3.zero;
            attackObject.SetActive(false);
            movement = Vector3.zero;
        }
    }

    protected override void BehaveSingleton()
    {
        StartAttack();
        Attack();
        FinishAttack();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
