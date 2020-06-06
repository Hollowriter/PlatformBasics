using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : SingletonBase<PlayerHealth>
{
    [SerializeField]
    int maximumHealth;
    int health;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        health = maximumHealth;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetHealth(int _health) 
    {
        health = _health;
        if (health > maximumHealth) 
        {
            health = maximumHealth;
        }
    }

    public int GetHealth() 
    {
        return health;
    }
}
