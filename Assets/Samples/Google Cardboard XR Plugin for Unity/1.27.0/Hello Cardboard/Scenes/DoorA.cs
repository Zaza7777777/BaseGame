using UnityEngine;

public class DoorA : MonoBehaviour
{
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.hasEscaped = true;
            StartCoroutine(GlitchTeleport(other.gameObject));
        }
    }

    System.Collections.IEnumerator GlitchTeleport(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        yield return new WaitForSeconds(0.5f);

        player.transform.position = respawnPoint.position;
        rb.isKinematic = false;
    }
}