using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAttackControll : MonoBehaviour
{
    public bool CanAttackPlayer; //Couldown for enemy attack
    public bool IsAttacking; 
    

    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject zombieAudioAttack;

    public Animator zombieAnim;

    public float range = 10f;
   

    void Start()
    {
        CanAttackPlayer = true;
        IsAttacking = false;       
    }
 
    void Update()
    {
        //Raycast checks if zombie is able to attack the player,
        RaycastHit hit;
        if(Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.forward, out hit, range))
        {        
                if(hit.transform.gameObject.tag == "Player"  && CanAttackPlayer)
            {
                ZombieAttack();
                
            }                   
        }

        if (IsAttacking) //Enables enemy hands colliders to deal damage
        {
            LeftHand.SetActive(true);
            RightHand.SetActive(true);           
        }
        if (!IsAttacking) //Prevent from taking damage when player is walking around the enemy but the enemy is not attacking
        {
            LeftHand.SetActive(false);
            RightHand.SetActive(false);          
        }
       
    }
   
       //Function picks random number to play random attack animation
    void ZombieAttack()
    {
        float animCyfra = Random.Range(0, 4);

        if(animCyfra == 1)
        {
            Invoke("ZombieAttackTriggerOn", 0.7f); //Enables hands colliders in specific moment of the animation to apply damage (Will be done in Animation Events)
            zombieAnim.SetTrigger("zombieAttack1");
            CanAttackPlayer = false; //Enables couldown for the enemy attack

            Invoke("ResetZombieAttack", 2f); //Enables reseting of the enemy attack couldown
            Invoke("ResetZombieAttackTrigger", 1f); //Disables hands colliders in specific moment of the animation (Will be done in Animation Events)

            zombieAudioAttack.GetComponent<RandomAttackAudio>().AttackAudio();
        }
        if (animCyfra == 2)
        {
            Invoke("ZombieAttackTriggerOn", 0.7f);
            zombieAnim.SetTrigger("zombieAttack2");
            CanAttackPlayer = false;

            Invoke("ResetZombieAttack", 2f);
            Invoke("ResetZombieAttackTrigger", 1.5f);

            zombieAudioAttack.GetComponent<RandomAttackAudio>().AttackAudio();
        }
        if (animCyfra == 3)
        {
            Invoke("ZombieAttackTriggerOn", 0.7f);
            zombieAnim.SetTrigger("zombieAttack3");
            CanAttackPlayer = false;

            Invoke("ResetZombieAttack", 2f);
            Invoke("ResetZombieAttackTrigger", 1.5f);

            zombieAudioAttack.GetComponent<RandomAttackAudio>().AttackAudio();
        }

    }

    void ResetZombieAttack()
    {
        CanAttackPlayer = true;
    }

    void ZombieAttackTriggerOn()
    {
        IsAttacking = true;
    }
    void ResetZombieAttackTrigger()
    {
        IsAttacking = false;
    }

}
