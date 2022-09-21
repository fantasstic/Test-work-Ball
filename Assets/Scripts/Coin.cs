using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _reward;
    private Collider _collider;
    public int Reward => _reward;
    public void OnTriggerEnter(Collider colission)
    {
        if (colission.TryGetComponent(out Ball ball))
        {
            Destroy(gameObject);
        }
    }


}
