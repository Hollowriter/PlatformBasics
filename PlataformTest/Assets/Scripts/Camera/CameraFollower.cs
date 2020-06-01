using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    GameObject objectToFollow;
    Vector3 offset;

    public void SetObjectToFollow(GameObject _objectToFollow) 
    {
        objectToFollow = _objectToFollow;
        offset = transform.position - objectToFollow.transform.position;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        SetObjectToFollow(PlayerMovement.instance.gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void Follow() 
    {
        transform.position = objectToFollow.transform.position + offset;
    }

    protected override void BehaveSingleton()
    {
        Follow();
    }

    private void LateUpdate()
    {
        BehaveSingleton();
    }
}
