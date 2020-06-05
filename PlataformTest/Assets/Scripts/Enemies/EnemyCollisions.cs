using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : ElementBase
{
    // Start is called before the first frame update
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
