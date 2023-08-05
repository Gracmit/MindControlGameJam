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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
            
    }
}