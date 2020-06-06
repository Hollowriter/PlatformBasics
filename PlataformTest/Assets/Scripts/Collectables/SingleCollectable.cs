using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCollectable : SingletonBase<SingleCollectable>
{
    private void Awake()
    {
        SingletonAwake();
    }
}
