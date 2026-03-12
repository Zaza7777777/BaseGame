using UnityEngine;

public class GlassBlock : MonoBehaviour
{
    
    public bool isFakeGlass;

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && isFakeGlass)
        {
            
            gameObject.SetActive(false);
        }
    }
}