using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPull : MonoBehaviour
{
    public static CoinPull Instance { get => instance; }
    private static CoinPull instance;

    [SerializeField]
    private Coin coinRef;

    [SerializeField]
    private int pullSize;

    private List<Coin> pull;

    private int index;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        index = 0;

        pull = new List<Coin>();
        for (var i = 0; i < pullSize; i++)
        {

            Coin tmp = Instantiate(coinRef);
            tmp.gameObject.SetActive(false);
            pull.Add(tmp);

        }

    }

    public Coin GetNext()
    {
        index = (index + 1) % pull.Count;
        return pull[index];
    }
}
