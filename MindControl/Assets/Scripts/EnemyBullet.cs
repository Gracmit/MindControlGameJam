using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _bulletSpeed;
    public void Shoot()
    {
        _rigidbody.AddForce(transform.forward * _bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var stats = collision.gameObject.GetComponent<PlayerStats>();
            stats.TakeHit(10);
        }

        Destroy(gameObject);
    }
}