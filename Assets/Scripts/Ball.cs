using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private Ball _ball;

    private int _money;

    public event UnityAction<int> MoneyChanged;
    private void Start()
    {
        _ball = GetComponent<Ball>();
    }
    public void AddMoney(int reward)
    {
        _money += reward;
        MoneyChanged?.Invoke(_money);
    }


}
