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
                
                foreach (GameObject platform in platformsToActivate)
                    if (platform != null)
                        platform.SetActive(false);
                return;
            }
        }

        
        foreach (GameObject platform in platformsToActivate)
            if (platform != null)
                platform.SetActive(true);
    }
}