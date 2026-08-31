using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [Header("Musiques")]
    public AudioClip[] musicClips;

    [Header("Source Audio")]
    public AudioSource audioSource;

    private int lastIndex = -1;

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        PlayRandomMusic();
    }

    void Update()
    {
        if (!audioSource.isPlaying && musicClips.Length > 0)
        {
            PlayRandomMusic();
        }
    }

    void PlayRandomMusic()
    {
        if (musicClips.Length == 0) return;

        int newIndex;

        if (musicClips.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            do
            {
                newIndex = Random.Range(0, musicClips.Length);
            } while (newIndex == lastIndex);
        }

        lastIndex = newIndex;

        audioSource.clip = musicClips[newIndex];
        audioSource.Play();
    }
}