using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float RotateSpeed = 100;
    public float ForwardSpeed = 5;
    public float JumpForce = 5;
    public float LookUpSpeed = 100; // Added look up/down speed
    public Transform VRCamera;

    private Rigidbody rb;
    private float verticalRotation = 0f; // Track vertical rotation
    public float maxLookAngle = 80f; // Limit how far up/down you can look

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        // Get left joystick direction (movement and rotation)
        Vector2 leftStick = gamepad.leftStick.ReadValue();

        // Get right joystick direction (looking up/down)
        Vector2 rightStick = gamepad.rightStick.ReadValue();

        // Rotate left/right based on left joystick's left/right position
        transform.eulerAngles += Vector3.up * (leftStick.x * RotateSpeed * Time.deltaTime);

        // Move forwards/backwards based on left joystick's up/down position
        transform.position += transform.forward * (leftStick.y * ForwardSpeed * Time.deltaTime);

        // NEW: Look up/down based on right joystick's up/down position
        if (VRCamera != null)
        {
            // Calculate vertical rotation change
            verticalRotation -= rightStick.y * LookUpSpeed * Time.deltaTime;

            // Clamp the vertical rotation to prevent over-rotation
            verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);

            // Apply the vertical rotation to the camera (local rotation)
            VRCamera.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        }

        // Raycast for object interaction
        RaycastHit hit;
        GameObject firstHitObject = null;

        if (Physics.Raycast(VRCamera.position, VRCamera.forward, out hit))
        {
            firstHitObject = hit.collider.gameObject;
        }

        // Pressed right bumper for interaction
        if (gamepad.rightShoulder.wasPressedThisFrame && (firstHitObject != null))
        {
            ObjectController objectController = firstHitObject.GetComponent<ObjectController>();
            objectController?.OnPointerClick();
        }

        // Jump when A button is pressed
        if (gamepad.buttonSouth.wasPressedThisFrame)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody attached to player. Jumping requires a Rigidbody component.");
        }
    }
}