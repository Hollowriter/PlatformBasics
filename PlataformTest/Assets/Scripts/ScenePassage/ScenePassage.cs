using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePassage : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    const string menuSceneName = "Menu";

    void DeleteAndReset() 
    {
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("InputManager"));
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Canvas"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if (sceneName == menuSceneName)
                DeleteAndReset();
            SceneManager.LoadScene(sceneName);
        }
    }
}
