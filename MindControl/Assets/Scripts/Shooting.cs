using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private int _ammoCount;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _ammoCount > 0)
        {
            Quaternion rotation = Camera.main.transform.rotation;
            var instantiatedObject = GameObject.Instantiate(_bullet, _shootingPoint.position, rotation);
            
            var bullet = instantiatedObject.GetComponent<Bullet>();
            bullet.Shoot();
        }
    }
}