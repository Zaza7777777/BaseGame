using UnityEngine;

public class TeleportPlatform : MonoBehaviour
{
    [Header("Target Platform")]
    [SerializeField] private Transform targetPlatform; 
    [SerializeField] private bool teleportOnTouch = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && teleportOnTouch)
        {
            Teleport(other.gameObject);
        }
    }

    private void Teleport(GameObject player)
    {
        
        player.transform.position = targetPlatform.position;

    
        player.transform.position += Vector3.up * 1f;
    }
}