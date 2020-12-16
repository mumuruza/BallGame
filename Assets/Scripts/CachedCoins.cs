using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachedCoins : MonoBehaviour
{
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private int cacheSize;

    private List<Coin> cache;
    private int index;

    private void Awake()
    {
        index = 0;

        cache = new List<Coin>();
        for (var i = 0; i < cacheSize; i++)
        {
            Coin tmp = Instantiate(coinPrefab);
            tmp.gameObject.SetActive(false);
            cache.Add(tmp);
        }
    }

    private Coin GetNext()
    {
        index = (index + 1) % cache.Count;
        return cache[index];
    }

    public Coin PlaceNext(Transform parent, Vector3 position)
    {
        Coin coin = GetNext();
        coin.transform.position = position;
        coin.transform.SetParent(parent);
        coin.gameObject.SetActive(true);
        return coin;
    }
}
