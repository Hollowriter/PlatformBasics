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
    }
}
