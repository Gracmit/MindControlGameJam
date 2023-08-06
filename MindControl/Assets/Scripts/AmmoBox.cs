using System;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;
    [SerializeField] private GameObject _bullets;
    private BoxCollider _collider;
    private AudioSource _audio;
    private float cdTimer = 0;
    private float cdTime = 10;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (cdTimer < Time.time && _collider.enabled == false)
        {
            _collider.enabled = true;
            _bullets.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audio.Play();
            var shooting = other.gameObject.GetComponent<Shooting>();
            shooting.AddAmmo(_ammoAmount);
            _collider.enabled = false;
            _bullets.SetActive(false);
            cdTimer = Time.time + cdTime;
        }
    }
}
