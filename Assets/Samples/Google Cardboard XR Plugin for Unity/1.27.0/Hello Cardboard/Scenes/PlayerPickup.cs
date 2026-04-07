using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 3f;

    private PickupBlock currentBlock;
    private Transform holdPosition;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        GameObject holdObj = new GameObject("HoldPosition");
        holdObj.transform.parent = playerCamera.transform;

        holdObj.transform.localPosition = new Vector3(0, -0.3f, 3f);
        //holdObj.transform.localPosition = new Vector3(0, -0.3f, 1.5f);
        holdPosition = holdObj.transform;
    }

    void Update()
    {
        
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (currentBlock != null)
                DropBlock();
            else
                TryPickup();
        }

        
        if (Gamepad.current != null && Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            if (currentBlock != null)
                DropBlock();
            else
                TryPickup();
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickupRange))
        {
            PickupBlock block = hit.collider.GetComponent<PickupBlock>();
            if (block != null && !block.isCarried)
            {
                currentBlock = block;
                currentBlock.Pickup(holdPosition);
            }
        }
    }

    void DropBlock()
    {
        currentBlock.Drop();
        currentBlock = null;
    }
}