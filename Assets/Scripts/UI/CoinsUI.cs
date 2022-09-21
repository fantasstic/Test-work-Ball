using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinsUI : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _coins;

    private void OnEnable()
    {
        _ball.MoneyChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _ball.MoneyChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coin)
    {
        _coins.text = coin.ToString();
    }
}
