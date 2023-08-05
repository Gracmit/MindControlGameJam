using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject _cannon;
    [SerializeField] private GameObject _cannonLegs;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPoint;

    private GameObject _player;
    private float _shootTimer = 0f;
    private float _shootingDelay = 1f;
    private void Awake()
    {
        _player = FindObjectOfType<Shooting>().gameObject;
        
    }

    void Update()
    {
        RotateCannon();
        if(_shootTimer < Time.time)
            Shoot();
    }

    private void Shoot()
    {
        _shootTimer = Time.time + _shootingDelay;
        var instantiatedObject = Instantiate(_bullet, _bulletPoint.position, _cannon.transform.rotation);
        var bullet = instantiatedObject.GetComponent<Bullet>();
        bullet.Shoot();
    }

    private void RotateCannon()
    {
        _cannonLegs.transform.LookAt(_player.transform.position);
        _cannonLegs.transform.localEulerAngles = new Vector3(0, _cannonLegs.transform.eulerAngles.y, 0);
        _cannon.transform.LookAt(_player.transform.position, _cannonLegs.transform.up);
       
    }
}
