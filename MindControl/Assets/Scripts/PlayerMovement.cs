using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _controller;
    private Vector3 _velocity;
    
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

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity.y = _jumpForce;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * (_speed * Time.deltaTime));

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
