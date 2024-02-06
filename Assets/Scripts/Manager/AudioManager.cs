using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;

    public static AudioManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void ClickSound()
    {
        audioSource.PlayOneShot(click);
    }
}
