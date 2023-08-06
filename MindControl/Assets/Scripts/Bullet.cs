using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _bulletSpeed;
    public void Shoot()
    {
        _rigidbody.AddForce(transform.forward * _bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var stats = other.gameObject.GetComponent<Enemy>();
            stats.TakeHit(15);
        }
        
        if(!other.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}