using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletonBase<InputManager>
{
    public KeyCode walkLeft { get; set; }
    public KeyCode walkRight { get; set; }
    public KeyCode jump { get; set; }
    public KeyCode attack { get; set; }
    /*public bool walkRightPressed;
    public bool walkLeftPressed;
    public bool jumpPressed;
    public bool attackPressed;*/


    public bool inputDetected()
    {
        if (Input.anyKey)
            return true;
        return false;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        SetActivated(true);
        walkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        walkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "J"));
        /*walkLeftPressed = false;
        walkRightPressed = false;
        jumpPressed = false;
        attackPressed = false;*/
    }

    void Awake()
    {
        SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }

    /*void CheckWalkLeft() 
    {
        if (Input.GetKey(walkLeft)) 
            walkLeftPressed = true;
        if (Input.GetKeyUp(walkLeft))
            walkLeftPressed = false;
    }

    void CheckWalkRight()
    {
        if (Input.GetKey(walkRight))
            walkRightPressed = true;
        if (Input.GetKeyUp(walkRight))
            walkRightPressed = false;
    }

    void CheckJump()
    {
        if (Input.GetKey(jump))
            jumpPressed = true;
        if (Input.GetKeyUp(jump))
            jumpPressed = false;
    }

    void CheckAttack()
    {
        if (Input.GetKey(attack))
            attackPressed = true;
        if (Input.GetKeyUp(attack))
            attackPressed = false;
    }

    protected override void BehaveSingleton()
    {
        CheckWalkLeft();
        CheckWalkRight();
        CheckJump();
        CheckAttack();
    }

    private void Update()
    {
        BehaveSingleton();
    }*/
}
