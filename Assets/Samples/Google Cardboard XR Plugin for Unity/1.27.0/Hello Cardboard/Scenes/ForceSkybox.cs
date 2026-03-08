using UnityEngine;

public class ForceSkybox : MonoBehaviour
{
    public Material skyboxMaterial;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (skyboxMaterial != null)
        {
            // Method 1: Set global skybox
            RenderSettings.skybox = skyboxMaterial;
        }
    }

    void Update()
    {
        // Method 2: Force this camera to use skybox EVERY frame
        if (cam != null)
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }

        // Method 3: Keep forcing the skybox material (VR sometimes resets it)
        if (RenderSettings.skybox != skyboxMaterial && skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
        }
    }

    void OnPreRender()
    {
        // Method 4: Right before rendering, force it again
        if (cam != null)
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }
    }
}