using UnityEngine;

public class PickupBlock : MonoBehaviour
{
    public bool isCarried = false;

    private Rigidbody rb;
    private Collider blockCollider;
    private Renderer blockRenderer;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        blockCollider = GetComponent<Collider>();
        blockRenderer = GetComponent<Renderer>();

        if (blockRenderer != null)
            originalColor = blockRenderer.material.color;

        gameObject.tag = "Block";
    }

    public void Pickup(Transform holdPosition)
    {
        isCarried = true;
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.parent = holdPosition;
        transform.localPosition = Vector3.zero;

        if (blockRenderer != null)
            blockRenderer.material.color = Color.yellow;

        
        Invoke("DisableCollider", 0.1f);
    }

    void DisableCollider()
    {
        blockCollider.enabled = false;
    }

    public void Drop()
    {
        isCarried = false;
        rb.isKinematic = false;
        rb.useGravity = true;
        blockCollider.enabled = true;
        transform.parent = null;

        if (blockRenderer != null)
            blockRenderer.material.color = originalColor;
    }
}