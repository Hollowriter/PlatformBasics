using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : SingletonBase<PlayerCollisions>
{
    private void Awake()
    {
        SingletonAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            if (collision.gameObject.activeInHierarchy)
            {
                CollectableCounter.instance.SetNumberOfCollectables(CollectableCounter.instance.GetNumberOfCollectables() + 1);
                collision.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "Pendulum") 
        {
            if (collision.gameObject.activeInHierarchy)
            {
                PlayerPendulum.instance.SetCollectionConfirmation(true);
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.activeInHierarchy && !PlayerInvulnerability.instance.GetActivated())
            {
                PlayerHealth.instance.SetHealth(PlayerHealth.instance.GetHealth() - 1);
                PlayerInvulnerability.instance.SetActivated(true);
            }
        }
    }
}
