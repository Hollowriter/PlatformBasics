using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : ElementBase
{
    void Awake()
    {
        ElementAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack") 
        {
            this.gameObject.SetActive(false);
        }
    }
}
