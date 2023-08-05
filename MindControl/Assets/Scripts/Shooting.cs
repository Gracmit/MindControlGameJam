using System;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private int _ammoCount;
    [SerializeField] private TMP_Text _ammoText;


    private void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _ammoCount > 0)
        {
            Quaternion rotation = Camera.main.transform.rotation;
            var instantiatedObject = GameObject.Instantiate(_bullet, _shootingPoint.position, rotation);
            
            var bullet = instantiatedObject.GetComponent<Bullet>();
            bullet.Shoot();
            _ammoCount--;
            UpdateAmmoText();
        }
    }

    public void UpdateAmmoText()
    {
        _ammoText.text = $"Amm0: {_ammoCount}";
    }
}