using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    const float standardColor = 255;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    float flickerLimit;
    float flickerTimer;
    Color color;

    private void Awake()
    {
        flickerTimer = 0;
        color = new Color(standardColor, standardColor, standardColor, standardColor);
    }

    void Flicker() 
    {
        if (PlayerInvulnerability.instance.GetActivated())
        {
            if (flickerTimer < flickerLimit)
            {
                flickerTimer += Time.deltaTime;
            }
            else
            {
                flickerTimer = 0;
            }
            color.r = flickerTimer;
            color.g = flickerTimer;
            color.b = flickerTimer;
        }
        sprite.color = color;
    }

    void Behave() 
    {
        Flicker();
    }

    private void Update()
    {
        Behave();
    }
}
