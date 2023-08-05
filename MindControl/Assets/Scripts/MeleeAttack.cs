using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;

    private float _meleeTimer;
    private float _meleeTime = 0.3f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _meleeTimer < Time.time)
        {
            _collider.enabled = true;
            _meleeTimer = Time.time + _meleeTime;
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
