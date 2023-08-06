using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _dashSpeed = 50f;
    [SerializeField] private float _dashTime = 0.5f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private ControlsData _controls;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isDashing;
    private Vector3 _dashVector;
    private float _dashTimer;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        var isGrounded = Physics.CheckSphere(_groundCheck.position, 0.3f, _groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        if (isGrounded && Input.GetKeyDown(_controls.Jump))
        {
            _velocity.y = _jumpForce;
        }
        float x = 0;
        float z = 0; 
        
        if (Input.GetKey(_controls.Forward))
        {
            z = 1;
        }

        if (Input.GetKey(_controls.Backwards))
        {
            z = -1;
        }

        if (Input.GetKey(_controls.Left))
        {
            x = -1;
        }
        
        if (Input.GetKey(_controls.Right))
        {
            x = 1;
        }
        

        
        if (!_isDashing && Input.GetKeyDown(_controls.Dash))
        {
            _isDashing = true;
            _dashVector = transform.right * x + transform.forward * z;
            if (_dashVector == Vector3.zero)
            {
                _dashVector = transform.forward;
            }
            _dashTimer = Time.time + _dashTime;
            _velocity.y = 0;
        }

        if (_isDashing)
        {
            _controller.Move(_dashVector * (_dashSpeed * Time.deltaTime));
        }

        if (_dashTimer < Time.time)
        {
            _isDashing = false;
        }

        if (!_isDashing)
        {
            Vector3 move = transform.right * x + transform.forward * z;
            _controller.Move(move * (_speed * Time.deltaTime));
            _velocity.y += _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }

    }
}
