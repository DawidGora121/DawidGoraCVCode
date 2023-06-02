using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttackAudio : MonoBehaviour
{
    public AudioSource zombieAttack1;
    public AudioSource zombieAttack2;
    public AudioSource zombieAttack3;


   public void AttackAudio()
    {
        float randomNum = Random.Range(0, 3);

        if(randomNum == 0)
        {
            zombieAttack1.Play();
            zombieAttack1.pitch = Random.Range(0.8f, 1.5f);
            zombieAttack1.volume = Random.Range(0.8f, 1f);
        }
        if (randomNum == 1)
        {
            zombieAttack2.Play();
            zombieAttack2.pitch = Random.Range(0.8f, 1.5f);
            zombieAttack2.volume = Random.Range(0.8f, 1f);
        }
        if (randomNum == 2)
        {
            zombieAttack3.Play();
            zombieAttack3.pitch = Random.Range(0.8f, 1.5f);
            zombieAttack3.volume = Random.Range(0.8f, 1f);
        }


    }

    void Update()
    {
       
    }
   
}
