using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private CollisionDetector player;

    public event Action GameLost;
    private void Start()
    {
        player.CollisionDetected += OnCollisionDetected;
        GameLost += () => { Time.timeScale = 0; };
        Time.timeScale = 1;
    }

    private void OnCollisionDetected(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Obstacle>(out Obstacle o))
        {
            GameLost?.Invoke();
        }
    }
}
