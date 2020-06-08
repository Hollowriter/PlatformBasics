using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CheckDeath();
    }

    public int GetHealth() 
    {
        return health;
    }

    void CheckDeath()
    {
        if (GetHealth() <= 0)
        {
            Destroy(GameObject.Find("Main Camera"));
            Destroy(GameObject.Find("InputManager"));
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("UI"));
            SceneManager.LoadScene("Menu");
        }
    }
}
