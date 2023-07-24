using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private Color[] colorLives;
    [SerializeField] private SpriteRenderer sr;

    private void Awake()
    {
        // change brick color to default
        sr.color = colorLives[lives-1];    
    }

    // Each time a brick takes damage decrease and change it's color if the live isn't 0
    private void OnCollisionEnter2D(Collision2D other)
    {
        lives--;

        if (lives <= 0)
        {
            BrickBreakerManager.numberOfBricks--;
            Destroy(gameObject);
            return;
        }

        sr.color = colorLives[lives - 1];
    }
}
