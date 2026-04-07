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
            
            RenderSettings.skybox = skyboxMaterial;
        }
    }

    void Update()
    {
        
        if (cam != null)
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }

        
        if (RenderSettings.skybox != skyboxMaterial && skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
        }
    }

    void OnPreRender()
    {
        
        if (cam != null)
        {
            cam.clearFlags = CameraClearFlags.Skybox;
        }
    }
}