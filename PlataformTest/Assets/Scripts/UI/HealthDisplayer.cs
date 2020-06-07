using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : SingletonBase<HealthDisplayer>
{
    [SerializeField]
    Text healthText;

    private void Awake()
    {
        SingletonAwake();
    }

    void DisplayHealth() 
    {
        healthText.text = "Health: " + PlayerHealth.instance.GetHealth().ToString();
    }

    protected override void BehaveSingleton()
    {
        DisplayHealth();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
