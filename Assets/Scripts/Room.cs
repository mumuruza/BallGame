using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public float Width;

    [SerializeField] private List<Transform> obstaclePoints;
    [SerializeField] private float chance;
    [SerializeField] private CoinSpawner coinSpawner;

    private List<Obstacle> obstacles = new List<Obstacle>();
    private List<Coin> coins = new List<Coin>();

    public bool IsOutsideViewPort(Camera cam) 
    {
        return cam.ViewportToWorldPoint(Vector3.zero).x > transform.position.x + Width / 2;
    }

    public void RegenerateRoom()
    {
        foreach (var o in obstacles)
        {
            o.gameObject.SetActive(false);
        }
        obstacles.Clear();

        foreach (var c in coins)
        {
            c.gameObject.SetActive(false);
        }
        coins.Clear();

        foreach (var i in obstaclePoints)
        {
            if(Random.value<chance)
            {
                Obstacle obst = ObstaclePull.Instance.GetNext();
                obst.Place(i);
                obst.gameObject.SetActive(true);
                obstacles.Add(obst);
            }
        }
        coins = coinSpawner.SpawnCoins(Width, transform);
    }
}
