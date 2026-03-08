using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector3 targetPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = pointB.position;
    }

    void FixedUpdate()
    {
        if (pointA == null || pointB == null) return;

        // Move platform
        Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Switch direction at ends
        if (Vector3.Distance(rb.position, targetPosition) < 0.01f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }
}