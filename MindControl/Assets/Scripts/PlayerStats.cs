using System;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private TMP_Text _healthText;

    private void Start()
    {
        SetHealth();
    }

    public void TakeHit(int amount)
    {
        _hp -= amount;
        if (_hp < 0)
        {
            _hp = 0;
            SetHealth();
            Die();
        }
        SetHealth();
    }

    private void SetHealth()
    {
        _healthText.text = $"HP: {_hp}";
    }

    private void Die()
    {
        // Do this sometime in the future
    }
}
