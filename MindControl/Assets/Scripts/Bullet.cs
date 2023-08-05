using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public void Shoot()
    {
        _rigidbody.AddForce(transform.forward * 1000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
            
    }
}