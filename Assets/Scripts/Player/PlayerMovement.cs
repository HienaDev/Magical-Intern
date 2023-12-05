using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalMouseSensitivity;
    [SerializeField] private float _verticalMouseSensitivity;
    [SerializeField] private float _maxHeadUpAngle;
    [SerializeField] private float _minHeadDownAngle;

    private CharacterController _characterController;
    private Transform           _head;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _head = GetComponentInChildren<Camera>().transform;

        HideCursor();
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        UpdatePlayerRotation();
        UpdateHeadRotation();
        Move();
    }

    private void UpdatePlayerRotation()
    {
        float rotation = Input.GetAxis("Mouse X") * _horizontalMouseSensitivity;

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHeadRotation()
    {
        Vector3 rotation = _head.localEulerAngles;

        rotation.x -= Input.GetAxis("Mouse Y") * _verticalMouseSensitivity;

        if (rotation.x < 180)
            rotation.x = Mathf.Min(rotation.x, _maxHeadUpAngle);
        else
            rotation.x = Mathf.Max(rotation.x, _minHeadDownAngle);

        _head.localEulerAngles = rotation;
    }

    private void Move()
    {
        float x = Input.GetAxis("Forward") * 5f  * Time.deltaTime;
        float z = Input.GetAxis("Strafe")  * 5f * Time.deltaTime;

        Vector3 move = transform.right * z + transform.forward * x;

        _characterController.Move(move);
    }

    public void SetSensitivity(float sensitivity)
    {
        _horizontalMouseSensitivity = sensitivity;
        _verticalMouseSensitivity   = sensitivity;
    }

    public float GetSensitivity()
    {
        return _horizontalMouseSensitivity;
    }

    //private void FixedUpdate()
    //{
    //    float x = Input.GetAxis("Forward") * 0.1f;
    //    float z = Input.GetAxis("Strafe") * 0.1f;

    //    Vector3 move = transform.right * z + transform.forward * x;

    //    _characterController.Move(move);
    //}
}
