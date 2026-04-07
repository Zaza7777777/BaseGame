using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float RotateSpeed = 100;
    public float ForwardSpeed = 5;
    public float JumpForce = 5;
    public float LookUpSpeed = 100; 
    public Transform VRCamera;

    private Rigidbody rb;
    private float verticalRotation = 0f; 
    public float maxLookAngle = 80f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null) return;

        
        Vector2 leftStick = gamepad.leftStick.ReadValue();

        
        Vector2 rightStick = gamepad.rightStick.ReadValue();

        
        transform.eulerAngles += Vector3.up * (leftStick.x * RotateSpeed * Time.deltaTime);

        
        transform.position += transform.forward * (leftStick.y * ForwardSpeed * Time.deltaTime);

        
        if (VRCamera != null)
        {
            
            verticalRotation -= rightStick.y * LookUpSpeed * Time.deltaTime;

            
            verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);

            
            VRCamera.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        }

        
        RaycastHit hit;
        GameObject firstHitObject = null;

        if (Physics.Raycast(VRCamera.position, VRCamera.forward, out hit))
        {
            firstHitObject = hit.collider.gameObject;
        }

        
        if (gamepad.rightShoulder.wasPressedThisFrame && (firstHitObject != null))
        {
            ObjectController objectController = firstHitObject.GetComponent<ObjectController>();
            objectController?.OnPointerClick();
        }

        
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