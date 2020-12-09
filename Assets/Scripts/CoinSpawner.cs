using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoinSpawner
{
    public float coinsSpawnOffset, maxDistanceToObstacle, startCoinsChainChanse, endCoinsChainChanse, coinsDistance;
    public float yOffset;
    private List<Coin> coins;

    public CoinSpawner()
    {
        coins = new List<Coin>();
    }

    public void SpawnCoins(float width, Transform transform)
    {
        foreach (var c in coins)
        {
            c.gameObject.SetActive(false);
        }
        coins.Clear();

        bool isInChain = false;

        for (float x = transform.position.x - width / 2 + coinsSpawnOffset;
                x < transform.position.x + width / 2 - coinsSpawnOffset;
                x += coinsDistance)
        {
            var colliders = Physics2D.OverlapCircleAll(new Vector2(x, transform.position.y), maxDistanceToObstacle);
            bool skip = false;

            foreach (var coll in colliders)
            {
                if (coll.TryGetComponent(out Obstacle tmp))
                {
                    skip = true;
                    break;
                }
            }

            if (skip)
            {
                isInChain = false;
                continue;
            }

            if (isInChain)
            {
                SpawnCoin(x, transform);
                if (Random.value < endCoinsChainChanse)
                {
                    isInChain = false;
                }
            }

            else if (Random.value < startCoinsChainChanse)
            {
                isInChain = true;
                SpawnCoin(x, transform);
            }
        }
    }

    private void SpawnCoin(float x, Transform transform)
    {
        Coin coin = CoinPull.Instance.GetNext();
        coin.transform.position = new Vector3(x, transform.position.y + yOffset);
        coin.transform.SetParent(transform);
        coin.gameObject.SetActive(true);
        coins.Add(coin);
    }
}
