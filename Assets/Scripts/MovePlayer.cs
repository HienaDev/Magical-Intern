using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private float horizontalMouseSensitivity;
    [SerializeField] private float verticalMouseSensitivity;

    [SerializeField] private float maxHeadUpAngle;
    [SerializeField] private float minHeadDownAngle;


    private CharacterController characterController;

    private Transform head;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponentInChildren<Camera>().transform;

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
        float rotation = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHeadRotation()
    {
        Vector3 rotation = head.localEulerAngles;

        rotation.x -= Input.GetAxis("Mouse Y") * verticalMouseSensitivity;


        if (rotation.x < 180)
            rotation.x = Mathf.Min(rotation.x, maxHeadUpAngle);
        else
            rotation.x = Mathf.Max(rotation.x, minHeadDownAngle);

        head.localEulerAngles = rotation;

    }


    private void Move()
    {
        float x = Input.GetAxis("Forward") * 5f  * Time.deltaTime;
        float z = Input.GetAxis("Strafe")  * 5f * Time.deltaTime;

        Vector3 move = transform.right * z + transform.forward * x;

        characterController.Move(move);
    }

    //private void FixedUpdate()
    //{
    //    float x = Input.GetAxis("Forward") * 0.1f;
    //    float z = Input.GetAxis("Strafe") * 0.1f;

    //    Vector3 move = transform.right * z + transform.forward * x;

    //    characterController.Move(move);
    //}
}
