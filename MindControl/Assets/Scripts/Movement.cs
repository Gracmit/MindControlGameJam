using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    private float _yRotation;
    private Camera _camera;
    private float _xRotation;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }


    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * _horizontalSpeed;
        var mouseY = Input.GetAxis("Mouse Y") * _verticalSpeed;

        _yRotation += mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -60, 45);

        _camera.transform.eulerAngles = new Vector3(_xRotation, _yRotation, 0f);
    }
}
