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
    }

    public void Playsound( AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}
