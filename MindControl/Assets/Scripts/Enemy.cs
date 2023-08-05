
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;

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
}
