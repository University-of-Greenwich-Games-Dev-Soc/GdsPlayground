using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MonoBehaviour
{
    [SerializeField] private ShootingController _controller;
    [SerializeField] private int _bulletCount = 20;
    [SerializeField] private float _health = 2;

    // Update is called once per frame
    private void Update()
    {
        if (!_controller.IsReady) return;
        
        var direction = 360f / _bulletCount;
        var directions = new List<float> {0f};
        
        for (int i = 1; i < _bulletCount; i++)
        {
            directions.Add(direction * i);
        }
        
        _controller.Shoot(directions);
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health > 0) return;

        Destroy(gameObject);
    }
}
