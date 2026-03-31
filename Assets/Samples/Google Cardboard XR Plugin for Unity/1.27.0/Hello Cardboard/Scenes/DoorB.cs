using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorB : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        // completely hidden and passthrough at start
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    void Update()
    {
        if (GameManager.hasEscaped)
        {
            // reveal and activate after teleport
            meshRenderer.enabled = true;
            boxCollider.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.hasEscaped)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}