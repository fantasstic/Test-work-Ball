using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Ball))]
public class BallCollisionHandler : MonoBehaviour
{
    private Ball _ball;

    private void Start()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out Coin coin))
        {
            _ball.AddMoney(coin.Reward);
        }
    }
}
