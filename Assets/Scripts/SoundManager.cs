using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance5;

    private AudioSource effectPlayer;

    public AudioClip shootSound;
    public AudioClip boostSound;
    public AudioClip buttonSound;
    public AudioClip starSound;

    void Awake()
    {
        if (!instance5) instance5 = this;
    }

    void Start()
    {
        effectPlayer = GetComponent<AudioSource>();
    }

    public void SetEffectVolume(float volume)
    {
        effectPlayer.volume = volume;
    }

    public static void bgm(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    //총알 발사 시
    public void playerShoot()
    {
        effectPlayer.PlayOneShot(shootSound);
    }

    //부스터 스킬 사용 시
    public void playerBoost()
    {
        effectPlayer.PlayOneShot(boostSound);
    }
    
    //UI 버튼 클릭 시
    public void buttonClick()
    {
        effectPlayer.PlayOneShot(buttonSound);
    }

    //별 획득 시
    public void StarPickUp()
    {
        effectPlayer.PlayOneShot(starSound);
    }
}
