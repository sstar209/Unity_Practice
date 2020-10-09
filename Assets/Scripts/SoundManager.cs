using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance5;

    private AudioSource musicPlayer;
    public AudioClip backgroundMusic;
    public AudioClip shootSound;
    public AudioClip boostSound;

    void Awake()
    {
        if (!instance5) instance5 = this;
    }

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        bgm(backgroundMusic, musicPlayer);
    }

    public static void bgm(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    public void playerShoot()
    {
        musicPlayer.PlayOneShot(shootSound);
    }

    public void playerBoost()
    {
        musicPlayer.PlayOneShot(boostSound);
    }
}
