using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public static SoundManager instance { get; private set;}

    private void Awake() {
        instance = this;
        source = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    public void Playsound( AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
