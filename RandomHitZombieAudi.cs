using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHitZombieAudi : MonoBehaviour
{
    public AudioSource zombieHitAudio1;
    public AudioSource zombieHitAudio2;
    public AudioSource zombieHitAudio3;


    public void RandomHitAudio()
    {
        float randomNum = Random.Range(0, 3);

        if (randomNum == 0)
        {          
            zombieHitAudio1.pitch = Random.Range(0.8f, 1.1f);
            zombieHitAudio1.volume = Random.Range(0.8f, 1f);
            zombieHitAudio1.Play();
        }
        if (randomNum == 1)
        {
            zombieHitAudio2.pitch = Random.Range(0.8f, 1.1f);
            zombieHitAudio2.volume = Random.Range(0.8f, 1f);
            zombieHitAudio2.Play();
        }
        if (randomNum == 2)
        {           
            zombieHitAudio3.pitch = Random.Range(0.8f, 1.5f);
            zombieHitAudio3.volume = Random.Range(0.8f, 1.1f);
            zombieHitAudio3.Play();
        }

    }


}
