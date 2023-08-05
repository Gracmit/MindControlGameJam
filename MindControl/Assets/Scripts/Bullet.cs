using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var stats = collision.gameObject.GetComponent<Enemy>();
            stats.TakeHit(15);
        }
        
        Destroy(gameObject);
    }
}