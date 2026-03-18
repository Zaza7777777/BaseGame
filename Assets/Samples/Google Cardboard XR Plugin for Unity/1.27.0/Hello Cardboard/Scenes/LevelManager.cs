using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public PressurePlate[] pressurePlates;
    public GameObject[] platformsToActivate;

    void Update()
    {
        CheckAllPlates();
    }

    void CheckAllPlates()
    {
        foreach (PressurePlate plate in pressurePlates)
        {
            if (!plate.isActivated)
            {
                // One plate is not pressed, hide everything
                foreach (GameObject platform in platformsToActivate)
                    if (platform != null)
                        platform.SetActive(false);
                return;
            }
        }

        // All plates are pressed, show everything
        foreach (GameObject platform in platformsToActivate)
            if (platform != null)
                platform.SetActive(true);
    }
}