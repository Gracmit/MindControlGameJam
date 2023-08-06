using TMPro;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private ControlsData _controls;
    [SerializeField] private Animator _animator;

    private float _meleeTimer;
    private float _meleeTime = 0.3f;
    private static readonly int Attack = Animator.StringToHash("Attack");

    void Update()
    {
        if (Input.GetKeyDown(_controls.Melee) && _meleeTimer < Time.time)
        {
            _collider.enabled = true;
            _meleeTimer = Time.time + _meleeTime;
            _animator.SetTrigger(Attack);
        }

        if (_meleeTimer < Time.time)
        {
            _collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.MeleeKill();
        }
    }
}
