using System;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            var stats = collision.gameObject.GetComponent<PlayerStats>();
            stats.AddHealth(2);
            Destroy(gameObject);
        }
    }
}
