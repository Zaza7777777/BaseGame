using UnityEngine;

public class SmoothSpin : MonoBehaviour
{
    public float rotationSpeed = 50.0f;  

    void Update()
    {
        
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

       
        // transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
    }
}