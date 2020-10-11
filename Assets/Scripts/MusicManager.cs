using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance10;

    private AudioSource musicPlayer;

    public AudioClip backgroundMusic;
    public AudioClip bossbgmMusic;
    public AudioClip failMusic;
    public AudioClip clearMusic;

    void Awake()
    {
        if (!instance10) instance10 = this;   
    }

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        bgm(backgroundMusic, musicPlayer);
    }

    //float인수를 받아와 오디오 소스의 볼륨을 조절 해주는 함수
    public void SetMusicVolume(float volume)
    {
        musicPlayer.volume = volume;
    }

    //브금 기본 베이스 설정
    public static void bgm(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }

    //보스 등장 시 브금
    public void bossbgm()
    {
        bgm(bossbgmMusic, musicPlayer);
    }

    //실패 시 브금
    public void failbgm()
    {
        bgm(failMusic, musicPlayer);
    }

    public void clearbgm()
    {
        bgm(clearMusic, musicPlayer);
    }   
}
