using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip backgroundMusic;

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        readySound(backgroundMusic, musicPlayer);

    }

    public static void readySound(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

}
