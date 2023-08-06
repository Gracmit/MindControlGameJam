using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private int _ammoCount;
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private ControlsData _controls;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioShooting;
    private static readonly int Shoot = Animator.StringToHash("Shoot");


    private void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetKeyDown(_controls.Shoot) && _ammoCount > 0)
        {
            _animator.SetTrigger(Shoot);
            _audioShooting.Play();
            Quaternion rotation = Camera.main.transform.rotation;
            var instantiatedObject = Instantiate(_bullet, _shootingPoint.position, rotation);
            
            var bullet = instantiatedObject.GetComponent<Bullet>();
            bullet.Shoot();
            _ammoCount--;
            UpdateAmmoText();
        }
    }

    public void UpdateAmmoText()
    {
        _ammoText.text = $"{_ammoCount}";
    }

    public void AddAmmo(int ammoAmount)
    {
        _ammoCount += ammoAmount;
        UpdateAmmoText();
    }
}