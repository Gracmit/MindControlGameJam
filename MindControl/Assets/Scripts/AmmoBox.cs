using System;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.AddAmmo(_ammoAmount);
        }
    }
}
