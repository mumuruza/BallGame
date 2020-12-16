using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    public event Action<int> CoinsChanged;

    public int Coins { get; private set; }

    private void Start()
    {
        Coins = 0;
        CoinsChanged?.Invoke(Coins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            Coins++;
            CoinsChanged?.Invoke(Coins);
            other.gameObject.SetActive(false);
        }
    }
}
