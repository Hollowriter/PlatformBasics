﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void BeginGame() 
    {
        SceneManager.LoadScene(sceneName);
    }
}
