using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsPresenter : MonoBehaviour
{
    [SerializeField] private CoinsCollector coinsCollector;
    [SerializeField] private Text counter;

    private void OnEnable()
    {
        coinsCollector.CoinsChanged += OnCoinValueChange;
    }

    private void OnDisable()
    {
        coinsCollector.CoinsChanged -= OnCoinValueChange;
    }

    private void OnCoinValueChange(int coins)
    {
        counter.text = coins.ToString();
    }
}
