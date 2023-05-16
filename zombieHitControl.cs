using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnimFollow;

public class zombieHitControl : MonoBehaviour
{
    RagdollControl_AF ragdollControl;

    public GameObject playerHandsAnim;
    public GameObject zombieMovement;
    public GameObject zombieRagdoll;
    public GameObject zombieSpine2;
    public GameObject hitParticle1;
    public GameObject zombieHitAudio;

    public Animator zombieAnim;

    public bool falling;
    public bool getUp;
    public bool seePlayer;

    Rigidbody rb;

    public float CanBeAttackedTimer = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerHandsAnim = GameObject.FindGameObjectWithTag("PlayerHands");

        falling = zombieRagdoll.GetComponent<RagdollControl_AF>().falling;
        getUp = zombieRagdoll.GetComponent<RagdollControl_AF>().gettingUp;
        seePlayer = zombieMovement.GetComponent<PlayerMovement_AF>().playerIsSeen;
    }

  
    void Update()
    {
        CanBeAttackedTimer -= Time.deltaTime;

       
    }
    void OnTriggerEnter(Collider other)
    {
        //If enemy collides with weapon collider and isAttacking bool (INSPECTOR: playerArms > handsAnim.cs) is set to true damage can be applied (Will be changed)
        if(other.tag == "Weapon" && playerHandsAnim.GetComponent<handsAnim>().isAttacking == true && CanBeAttackedTimer < 0)
        {
            //Instantiate blood particle at the collision transform
            Instantiate(hitParticle1, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);  
                       
            ZombieHitReaction();

            //Calls the random hit audio source (INSPECTOR: Zombie_working > zombieAnimated > AudioZombie > RandomHitZombieAudi.cs)
            zombieHitAudio.GetComponent<RandomHitZombieAudi>().RandomHitAudio();

            CanBeAttackedTimer = CanBeAttackedTimer;
        }

    }

    public void ZombieHitReaction()
    {
        //When the player hits enemy, he instantly chases the player by switching  playerIsSeen bool (INSPECTOR: Zombie_working > zombieAnimated > PlayerMovement_AF.cs)
        zombieMovement.GetComponent<PlayerMovement_AF>().playerIsSeen = true;

        if (Random.value > 0.10)
        {
            //Do damage
           

        }

        if(Random.value < 0.90)
        {

            //When the player attacks function (INSPECTOR: playerArms > handsAnim.cs) picks animation attack, 0 swings from right to the left side,  1 swings from left to the right
            if (playerHandsAnim.GetComponent<handsAnim>().animTypeAttack == 0)
            {
                //After calling ZombieHitReaction() function picks randomly animation, animation is mirrored depending on the player's attack aniamtion
                float animCyfra = Random.Range(0, 4);
                           
                if (animCyfra == 0)
                {
                     zombieAnim.SetTrigger("HitReaction1");  
                }
                if (animCyfra == 1)
                {
                    zombieAnim.SetTrigger("HardHitReaction1");
                }
                if (animCyfra == 2)
                {
                    zombieAnim.SetTrigger("hardHit1");
                }
                if (animCyfra == 3)
                {
                    zombieAnim.SetTrigger("hardHit3");
                }
                

            }
            
            if (playerHandsAnim.GetComponent<handsAnim>().animTypeAttack == 1)
            {
                float animCyfra = Random.Range(0, 4);

                if(animCyfra == 0)
                {
                    zombieAnim.SetTrigger("HitReaction2");
                }
                if (animCyfra == 1)
                {
                     zombieAnim.SetTrigger("HardHitReaction2");
                }
                if (animCyfra == 2)
                {
                    zombieAnim.SetTrigger("hardHit2");
                }
                if (animCyfra == 3)
                {
                    zombieAnim.SetTrigger("hardHit4");
                }
                
               
            }

        }
        
        
    }

   public void DestroyBloodParticle()
    {
        Destroy(hitParticle1);
    }
}
