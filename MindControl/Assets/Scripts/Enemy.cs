using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private GameObject _healthPickUp;

    public void TakeHit(int amount)
    {
        _hp -= amount;
        if (_hp < 0)
        {
            _hp = 0;

            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void MeleeKill()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(_healthPickUp, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}