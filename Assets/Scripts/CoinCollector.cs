using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action<int> CoinValueChanged;
    private int coins;

    public int Coins => coins;

    private void Start()
    {
        coins = 0;
        CoinValueChanged?.Invoke(coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coins++;
            CoinValueChanged?.Invoke(coins);
            other.gameObject.SetActive(false);
        }
    }
}
