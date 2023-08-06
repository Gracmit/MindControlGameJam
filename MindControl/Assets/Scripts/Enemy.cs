using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private GameObject _healthPickUp;
    [SerializeField] private AudioSource _audioHit;

    public void TakeHit(int amount)
    {
        _audioHit.Play();
        _hp -= amount;
        if (_hp < 0)
        {
            _hp = 0;

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