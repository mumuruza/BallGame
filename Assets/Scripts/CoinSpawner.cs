using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CachedCoins cachedCoins;
    [SerializeField] private float coinsSpawnOffset;
    [SerializeField] private float maxDistanceToObstacle;
    [SerializeField] private float startCoinsChainChanse;
    [SerializeField] private float endCoinsChainChanse;
    [SerializeField] private float coinsDistance;
    [SerializeField] private float yOffset;

    public List<Coin> SpawnCoins(float width, Transform parent)
    {
        List<Coin> coins = new List<Coin>();

        bool isInChain = false;
        float startPoint = parent.position.x - width / 2 + coinsSpawnOffset;
        float endPoint = parent.position.x + width / 2 - coinsSpawnOffset;

        for (float x = startPoint; x < endPoint; x += coinsDistance)
        {
            if (CanSpawn(new Vector2(x, parent.position.y)) == false)
            {
                isInChain = false;
                continue;
            }

            if (isInChain)
            {
                SpawnCoin(x, parent, coins);
                if (Random.value < endCoinsChainChanse)
                {
                    isInChain = false;
                }
            }

            else if (Random.value < startCoinsChainChanse)
            {
                isInChain = true;
                SpawnCoin(x, parent, coins);
            }
        }
        return coins;
    }

    private void SpawnCoin(float x, Transform parent, List<Coin> coins)
    {
        Coin coin = cachedCoins.PlaceNext(parent, new Vector3(x, parent.position.y + yOffset));
        coins.Add(coin);
    }

    private bool CanSpawn(Vector2 position) 
    {
        var colliders = Physics2D.OverlapCircleAll(position, maxDistanceToObstacle);

        foreach (var coll in colliders)
        {
            if (coll.TryGetComponent(out Obstacle tmp))
            {
                return false;
            }
        }
        return true;
    }
}
