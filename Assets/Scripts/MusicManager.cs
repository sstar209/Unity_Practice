using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicPlayer;

    public AudioClip backgroundMusic;
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

    public static void bgm(AudioClip clip, AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.clip = clip;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }


}
