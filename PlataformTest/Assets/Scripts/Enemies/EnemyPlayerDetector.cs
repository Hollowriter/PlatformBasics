using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyPlayerDetector : ElementBase
{
    [SerializeField]
    GameObject enemyDad;

    private void Awake()
    {
        ElementAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            enemyDad.GetComponent<EnemyMovement>().SetAttacking(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyDad.GetComponent<EnemyMovement>().SetAttacking(false);
        }
    }
}
