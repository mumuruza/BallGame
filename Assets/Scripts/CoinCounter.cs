using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField]
    private CoinCollector coinCollector;
    [SerializeField]
    private Text counter;

    private void Awake()
    {
        coinCollector.CoinValueChanged += OnCoinValueChange;
    }

    private void OnCoinValueChange(int coinCount)
    {
        counter.text = coinCount.ToString();
    }

    
}
