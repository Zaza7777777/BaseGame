using UnityEngine;

public class SmoothSpin : MonoBehaviour
{
    public float rotationSpeed = 50.0f;  // Degrees per second

    void Update()
    {
        // Rotate around Y-axis at a constant speed
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Alternative: Rotate around all axes
        // transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
    }
}