using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private bool lockCursor; //+
    [SerializeField] private bool enableJump; //+
    [SerializeField] private bool invertCamera; //-
    [SerializeField] private float walkSpeed; //5
    [SerializeField] private float mouseSensitivity; //2
    [SerializeField] private float maxLookAngle; //50
    [SerializeField] private float maxVelocityChange; //10
    [SerializeField] private float jumpPower; //5

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    Vector3 _direction;
    private float _rotation;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private bool isGrounded = true;

    private void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

        if (!invertCamera)
        {
            pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        }
        else
        {
            // Inverted Y
            pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
        }

        pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        transform.localEulerAngles = new Vector3(0, yaw, 0);
        playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

        if (enableJump && Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        targetVelocity = transform.TransformDirection(targetVelocity) * walkSpeed;

        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            //isGrounded = false;
        }
    }
}
