using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private GameObject _healthPickUp;
    [SerializeField] private AudioSource _audioHit;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.value = _hp;
    }

    public void TakeHit(int amount)
    {
        _slider.value = _hp;
        _audioHit.Play();
        _hp -= amount;
        if (_hp < 0)
        {
            _hp = 0;
            _slider.value = _hp;
            Die();
        }
    }

    private void Die()
    {
        WaveManager.Instance.EnemyDied();
        Destroy(gameObject);
    }

    public void MeleeKill()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(_healthPickUp, transform.position, Quaternion.identity);
        }
        WaveManager.Instance.EnemyDied();
        Destroy(gameObject);
    }
}