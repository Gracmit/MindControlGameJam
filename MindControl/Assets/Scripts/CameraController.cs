using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    private Camera _camera;
    private float _xRotation;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * _horizontalSpeed * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * _verticalSpeed * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -60, 45);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
