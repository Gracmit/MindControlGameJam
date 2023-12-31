using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private AudioSource _audioTakeHIt;

    private void Start()
    {
        SetHealth();
    }

    public void TakeHit(int amount)
    {
        _audioTakeHIt.Play();
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
        WaveManager.Instance.Reset();
        SceneManager.LoadScene("StartScene");
    }

    public void AddHealth(int amount)
    {
        _hp += amount;
        if (_hp > _maxHp)
        {
            _hp = _maxHp;
        }
        
        SetHealth();
    }
}
