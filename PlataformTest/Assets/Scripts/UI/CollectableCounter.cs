using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCounter : SingletonBase<CollectableCounter>
{
    [SerializeField]
    Text collectableText;
    int numberOfCollectables;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        numberOfCollectables = 0;
        collectableText.text = numberOfCollectables.ToString();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetNumberOfCollectables(int _numberOfCollectables) 
    {
        numberOfCollectables = _numberOfCollectables;
        collectableText.text = numberOfCollectables.ToString();
    }

    public int GetNumberOfCollectables() 
    {
        return numberOfCollectables;
    }
}
