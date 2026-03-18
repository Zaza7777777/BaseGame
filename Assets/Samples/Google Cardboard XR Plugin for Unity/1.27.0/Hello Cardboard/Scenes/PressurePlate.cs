using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] platformsToActivate;

    private Renderer plateRenderer;
    private Color originalColor;
    public bool isActivated = false;

    void Start()
    {
        plateRenderer = GetComponent<Renderer>();
        GetComponent<Collider>().isTrigger = true;

        if (plateRenderer != null)
        {
            plateRenderer.material.color = Color.red;
            originalColor = Color.red;
        }

        foreach (GameObject platform in platformsToActivate)
            if (platform != null)
                platform.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isActivated = true;

            if (plateRenderer != null)
                plateRenderer.material.color = Color.green;

            Debug.Log("Plate activated!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            isActivated = false;

            if (plateRenderer != null)
                plateRenderer.material.color = originalColor;

            Debug.Log("Plate deactivated!");
        }
    }
}