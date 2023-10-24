using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController playerController;

    [SerializeField] private float forwardAcceleration;
    [SerializeField] private float backwardAcceleration;

    [SerializeField] private float strafeAcceleration;

    [SerializeField] private float jumpAcceleration;
    [SerializeField] private float gravityAcceleration;
    
    [SerializeField] private float maxBackwardVelocity;
    [SerializeField] private float maxForwardVelocity;
    [SerializeField] private float maxStrafeVelocity;
    [SerializeField] private float maxFallVelocity;

    [SerializeField] private float horizontalMouseSensitivity;
    [SerializeField] private float verticalMouseSensitivity;

    [SerializeField] private float maxHeadUpAngle;
    [SerializeField] private float minHeadDownAngle;

    private Transform head;

    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 motion; // displacement

    private bool startJump;

    private float sin45;

    // Start is called before the first frame update
    private void Start()
    {
        playerController    = GetComponent<CharacterController>();
        head                = GetComponentInChildren<Camera>().transform;

        acceleration        = Vector3.zero;
        velocity            = Vector3.zero;
        motion              = Vector3.zero;

        startJump           = false;

        sin45               = Mathf.Sin(Mathf.PI / 4);

        HideCursor();
    }

    private void Update()
    {
        UpdateBodyRotation();
        UpdateHeadRotation();

        CheckForJump();
    }

    private void UpdateBodyRotation()
    {
        float rotation = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;

        transform.Rotate(0f, rotation, 0f);
    }

    private void UpdateHeadRotation()
    {
        Vector3 rotation = head.localEulerAngles;

        rotation.x -= Input.GetAxis("Mouse Y") * verticalMouseSensitivity;

        Debug.Log(rotation.x);

        if (rotation.x < 180)
            rotation.x = Mathf.Min(rotation.x, maxHeadUpAngle);
        else
            rotation.x = Mathf.Max(rotation.x, minHeadDownAngle);

        head.localEulerAngles = rotation;

    }
    private void CheckForJump()
    {
        if (Input.GetButtonDown("Jump") && playerController.isGrounded)
        {
            startJump = false;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        UpdateForwardAcceleration();
        UpdateStrafeAcceleration();
        UpdateVerticalAcceleration();
    }

    private void UpdateForwardAcceleration()
    {
        float forwardAxis = Input.GetAxis("Forward");

        if (forwardAxis > 0f)
        {
            acceleration.z = forwardAcceleration;
        }
        else if(forwardAxis < 0f)
        {
            acceleration.z = backwardAcceleration;
        }
        else
        {
            acceleration.z = 0f;
        }
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UpdateStrafeAcceleration()
    {
        float strafeAxis = Input.GetAxis("Strafe");

        if (strafeAxis > 0f)
        {
            acceleration.x = strafeAcceleration;
        }
        else if (strafeAxis < 0f)
        {
            acceleration.x = -strafeAcceleration;
        }
        else
        {
            acceleration.x = 0f;
        }
    }

    private void UpdateVerticalAcceleration()
    {
        //if (startJump)
        //{
        //    acceleration.y = jumpAcceleration;
        //}
        //else
        //{
        //    acceleration.y = gravityAcceleration;
        //}
    }

    private void UpdateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;


        if (acceleration.z == 0 || acceleration.z * velocity.z < 0) velocity.z = 0f;
        else if (velocity.x == 0f) velocity.z = Mathf.Clamp(velocity.z, maxBackwardVelocity, maxForwardVelocity);
        else velocity.z = Mathf.Clamp(velocity.z, maxBackwardVelocity * sin45, maxForwardVelocity * sin45);

        if (acceleration.x == 0 || acceleration.x * velocity.x < 0) velocity.x = 0f;
        else if (velocity.z == 0) velocity.x = Mathf.Clamp(velocity.x, -maxStrafeVelocity, maxStrafeVelocity);
        else velocity.x = Mathf.Clamp(velocity.x, -maxStrafeVelocity * sin45, maxStrafeVelocity * sin45);

        //if (playerController.isGrounded && !startJump)
        //{
        //    velocity.y -= 0.1f;
        //}
        //else
        //    velocity.y = Mathf.Max(velocity.y, maxFallVelocity);

        //startJump = false;
    }

    private void UpdatePosition()
    {
        motion = velocity * Time.fixedDeltaTime;

        motion = transform.TransformVector(motion);

        playerController.Move(motion);
    }
}
