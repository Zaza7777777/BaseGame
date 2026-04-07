using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 
    public AudioSource musicSource;
    public AudioClip[] tracks;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else Destroy(gameObject);
    }

    public void PlayTrack(int index)
    {
        musicSource.clip = tracks[index];
        musicSource.Play();
    }
}