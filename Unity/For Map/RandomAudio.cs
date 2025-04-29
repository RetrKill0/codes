using UnityEngine;

//By RetrKill0
[RequireComponent(typeof(AudioSource))]
public class RandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips; 
    public AudioClip audioClip; 
    private AudioSource audioSource; 
    int clipIndex; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioClips.Length > 0) audioSource.clip = GetSong();
        audioSource.time = Random.Range(0f, audioClip.length);
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.clip = NextSong(); 
            audioSource.Play();
        }
    }

    AudioClip GetSong() 
    {
        clipIndex = Random.Range(0, audioClips.Length - 1);
        return audioClips[clipIndex]; 
    }

    AudioClip NextSong() 
    {
        clipIndex = (clipIndex++ >= audioClips.Length) ? 0 : clipIndex++;
        return audioClips[clipIndex]; 
    }
}