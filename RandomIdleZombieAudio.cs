using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleZombieAudio : MonoBehaviour
{
    public AudioSource IdleAudio1;
    public AudioSource IdleAudio2;
    public AudioSource IdleAudio3;

    private float idleAudioTimer = 3f;

    void Update()
    {
        idleAudioTimer -= Time.deltaTime;

        if(idleAudioTimer < 0)
        {
            RandomIdleAudio();
            idleAudioTimer = Random.Range(4, 8);
        }

    }

    private void RandomIdleAudio()
    {
        float randomNum = Random.Range(0, 3);

        if (randomNum == 0)
        {
            IdleAudio1.pitch = Random.Range(0.6f, 1.1f);
            IdleAudio1.volume = Random.Range(0.7f, 1f);
            IdleAudio1.Play();
        }
        if (randomNum == 1)
        {
            IdleAudio2.pitch = Random.Range(0.6f, 1.1f);
            IdleAudio2.volume = Random.Range(0.7f, 1f);
            IdleAudio2.Play();
        }
        if (randomNum == 2)
        {
            IdleAudio3.pitch = Random.Range(0.6f, 1.1f);
            IdleAudio3.volume = Random.Range(0.7f, 1f);
            IdleAudio3.Play();
        }


    }

}
