using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By RetrKill0
public class AmbienceSounds : MonoBehaviour
{

    public AudioClip[] sounds;
    public AudioSource AudioSource;
  
    void Start () {
        CallAudio();
    }
 
    void CallAudio()
    {
        Invoke ("RandomSoundness", 60);
    }
 
    void RandomSoundness()
    {
        AudioSource.clip = sounds[Random.Range(0, sounds.Length)];
        AudioSource.Play ();
        CallAudio ();
    }
}

