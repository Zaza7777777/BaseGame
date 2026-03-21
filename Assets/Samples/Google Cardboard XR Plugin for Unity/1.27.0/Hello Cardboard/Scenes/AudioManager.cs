using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton to persist between scenes
    public AudioSource musicSource;
    public AudioClip[] tracks;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps music playing across scenes
        }
        else Destroy(gameObject);
    }

    public void PlayTrack(int index)
    {
        musicSource.clip = tracks[index];
        musicSource.Play();
    }
}